using System;
using System.Collections.Generic;
using System.Linq;

using Moq;

using Notos.Database.Interfaces;
using Notos.Database.Models.QueryModels;
using Notos.Database.Queries;
using Notos.Database.Repositories;

using Xunit;

namespace Notos.Database.UnitTests
{
    public class FlightsRepositoryUnitTests
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

            var mockFlightList = new List<FlightItemQueryDto>
            {
                testFlight1,
                testFlight2
            };
            var mockFlightRepository = new Mock<ISqlRepository>();


            mockFlightRepository.Setup(x => x.QueryAsync<FlightItemQueryDto>(FlightsQueries.GetAllFlights, null))
                .ReturnsAsync(mockFlightList)
                .Verifiable();
            var repository = new FlightsRepository(mockFlightRepository.Object);

            // Act
            var response = await repository.GetAllFlights();
            var flightItems = response.ToList();

            // Assert
            Assert.NotNull(response);
            Assert.Contains(testFlight1, flightItems);
            Assert.Contains(testFlight2, flightItems);

            mockFlightRepository.VerifyAll();
        }

        [Fact]
        public async void GetFlightById_Returns_The_Flight_When_It_Exists()
        {
            // Arrange
            var mockFlightItem = new FlightItemQueryDto
            {
                Id = 1,
                Site = "Dalefield",
                LaunchedAt = new DateTime(2021, 10, 1, 10, 00, 00),
                LandedAt = new DateTime(2021, 10, 1, 11, 00, 00),
                Distance = 10,
                Notes = "Test flight"
            };

            var mockFlightList = new List<FlightItemQueryDto>
            {
                mockFlightItem
            };

            var mockFlightRepository = new Mock<ISqlRepository>();

            mockFlightRepository.Setup(x => x.QueryAsync<FlightItemQueryDto>(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(mockFlightList)
                .Verifiable();
            var repository = new FlightsRepository(mockFlightRepository.Object);

            // Act
            var response = await repository.GetFlightById(1);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(mockFlightItem, response);

            mockFlightRepository.VerifyAll();
        }
    }
}
