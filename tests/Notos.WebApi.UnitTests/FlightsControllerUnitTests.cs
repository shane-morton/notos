using System;
using System.Collections.Generic;
using System.Net;

using Moq;

using Notos.Database.Models.QueryModels;
using Notos.Service.Interfaces;
using Notos.WebApi.Controllers;

using Xunit;

namespace Notos.WebApi.UnitTests
{
    public class FlightsControllerUnitTests
    {
        [Fact]
        public async void GetAllFlights_Returns_A_Collection_Of_Flights()
        {
            // Arrange
            var mockFlightService = new Mock<IFlightsService>();
            var mockFlightList = new List<FlightItemQueryDto>
            {
                new FlightItemQueryDto
                {
                    Id = 1,
                    Site = "Dalefield",
                    LaunchedAt = new DateTime(2021, 10, 1, 10, 00, 00),
                    LandedAt = new DateTime(2021, 10, 1, 10, 00, 00),
                    Distance = 10,
                    Notes = "Test flight"
                }
            };

            mockFlightService.Setup(x => x.GetAllFlights())
                .ReturnsAsync(mockFlightList);
            var controller = new FlightsController(mockFlightService.Object);

            // Act
            var response = await controller.GetAllFlights();

            // Assert
            Assert.NotNull(response);
        }


        [Fact]
        public async void GetFlightsById_Returns_The_Flight_When_It_Exists()
        {
            // Arrange
            var mockFlightService = new Mock<IFlightsService>();
            var mockFlightItem = new FlightItemQueryDto
            {
                Id = 1,
                Site = "Dalefield",
                LaunchedAt = new DateTime(2021, 10, 1, 10, 00, 00),
                LandedAt = new DateTime(2021, 10, 1, 10, 00, 00),
                Distance = 10,
                Notes = "Test flight"
            };


            mockFlightService.Setup(x => x.GetFlightById(It.IsAny<int>()))
                .ReturnsAsync(mockFlightItem);
            var controller = new FlightsController(mockFlightService.Object);

            // Act
            var response = await controller.GetFlightById(1);

            mockFlightService.Verify(m => m.GetFlightById(1), Times.Once());

            // Assert
            Assert.NotNull(response);
            Assert.Equal(mockFlightItem, response.Value);
        }
    }
}


