using System;
using System.Collections.Generic;
using System.Linq;

using Moq;

using Notos.Database.Interfaces;
using Notos.Database.Models.CommandModels;
using Notos.Database.Models.QueryModels;

using Xunit;

namespace Notos.Service.UnitTests
{
    public class FlightsServiceUnitTests
    {
        [Fact]
        public async void GetAllFlights_Returns_A_Collection_Of_Flights()
        {
            // Arrange
            var testFlight1 = new FlightItemQueryDto
            {
                Id = 1,
                Site = "Dalefield",
                LaunchedAt = new DateTime(2021, 10, 1, 10, 00, 00),
                LandedAt = new DateTime(2021, 10, 1, 11, 00, 00),
                Distance = 10,
                Notes = "Test flight"
            };
            var testFlight2 = new FlightItemQueryDto
            {
                Id = 2,
                Site = "Kourarau",
                LaunchedAt = new DateTime(2021, 10, 2, 10, 00, 00),
                LandedAt = new DateTime(2021, 10, 2, 11, 00, 00),
                Distance = 20,
                Notes = "Test flight"
            };
            var mockFlightRepository = new Mock<IFlightsRepository>();
            var mockFlightList = new List<FlightItemQueryDto>
            {
                testFlight1,
                testFlight2
            };

            mockFlightRepository.Setup(x => x.GetAllFlights())
                .ReturnsAsync(mockFlightList)
                .Verifiable();
            var service = new FlightsService(mockFlightRepository.Object);

            // Act
            var response = await service.GetAllFlights();
            var flightItems = response.ToList();

            // Assert
            Assert.NotNull(response);
            Assert.Contains(testFlight1, flightItems);
            Assert.Contains(testFlight2, flightItems);

            mockFlightRepository.VerifyAll();
        }

        [Fact]
        public async void GetFlightsById_Returns_The_Flight_When_It_Exists()
        {
            // Arrange
            var mockFlightRepository = new Mock<IFlightsRepository>();
            var mockFlightItem = new FlightItemQueryDto
            {
                Id = 1,
                Site = "Dalefield",
                LaunchedAt = new DateTime(2021, 10, 1, 10, 00, 00),
                LandedAt = new DateTime(2021, 10, 1, 10, 00, 00),
                Distance = 10,
                Notes = "Test flight"
            };


            mockFlightRepository.Setup(x => x.GetFlightById(It.IsAny<int>()))
                .ReturnsAsync(mockFlightItem)
                .Verifiable();
            var service = new FlightsService(mockFlightRepository.Object);

            // Act
            var response = await service.GetFlightById(1);


            // Assert
            Assert.NotNull(response);
            Assert.Equal(mockFlightItem, response);

            mockFlightRepository.Verify(m => m.GetFlightById(1), Times.Once());
        }

        [Fact]
        public async void CreateFlight_Returns_1_When_Flight_Created()
        {
            // Arrange
            var mockFlightRepository = new Mock<IFlightsRepository>();
            var mockFlightItem = new FlightItemCommandDto
            {
                Site = "Dalefield",
                LaunchedAt = new DateTime(2021, 10, 1, 10, 00, 00),
                LandedAt = new DateTime(2021, 10, 1, 11, 00, 00),
                Distance = 10,
                Notes = "Test flight"
            };

            mockFlightRepository.Setup(x => x.CreateFlight(mockFlightItem))
                .ReturnsAsync(1)
                .Verifiable();

            var service = new FlightsService(mockFlightRepository.Object);

            // Act
            var response = await service.CreateFlight(mockFlightItem);

            // Assert
            Assert.True(response);

            mockFlightRepository.Verify(m => m.CreateFlight(mockFlightItem), Times.Once());
        }

        [Fact]
        public async void CreateFlight_Returns_0_When_Flight_Not_Created()
        {
            // Arrange
            var mockFlightRepository = new Mock<IFlightsRepository>();
            var mockFlightItem = new FlightItemCommandDto
            {
                Site = "Dalefield",
                LaunchedAt = new DateTime(2021, 10, 1, 10, 00, 00),
                LandedAt = new DateTime(2021, 10, 1, 11, 00, 00),
                Distance = 10,
                Notes = "Test flight"
            };

            mockFlightRepository.Setup(x => x.CreateFlight(mockFlightItem))
                .ReturnsAsync(0)
                .Verifiable();

            var service = new FlightsService(mockFlightRepository.Object);

            // Act
            var response = await service.CreateFlight(mockFlightItem);

            // Assert
            Assert.False(response);

            mockFlightRepository.Verify(m => m.CreateFlight(mockFlightItem), Times.Once());
        }

        //todo: Add remaining Service unit tests
    }
}
