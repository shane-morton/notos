using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;

using Moq;

using Notos.Database.Models.CommandModels;
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
            var mockFlightService = new Mock<IFlightsService>();
            var mockFlightList = new List<FlightItemQueryDto>
            {
                testFlight1,
                testFlight2
            };

            mockFlightService.Setup(x => x.GetAllFlights())
                .ReturnsAsync(mockFlightList);
            var controller = new FlightsController(mockFlightService.Object);

            // Act
            var response = await controller.GetAllFlights();

            // Assert
            var flightItems = response.ToList();
            Assert.NotNull(response);
            Assert.Contains(testFlight1, flightItems);
            Assert.Contains(testFlight2, flightItems);
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


        [Fact]
        public async void AddFlight_Returns_Success_When_Flight_Created()
        {
            // Arrange
            var mockFlightService = new Mock<IFlightsService>();
            var mockFlightItem = new FlightItemCommandDto
            {
                Site = "Dalefield",
                LaunchedAt = new DateTime(2021, 10, 1, 10, 00, 00),
                LandedAt = new DateTime(2021, 10, 1, 11, 00, 00),
                Distance = 10,
                Notes = "Test flight"
            };

            mockFlightService.Setup(x => x.CreateFlight(mockFlightItem))
                .ReturnsAsync(true)
                .Verifiable();

            var controller = new FlightsController(mockFlightService.Object)
            {
                ControllerContext = { HttpContext = new DefaultHttpContext(), RouteData = new RouteData() }
            };
            controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor { ActionName = "Success" };

            // Act
            var response = await controller.AddFlight(mockFlightItem);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<CreatedAtActionResult>(response);
            mockFlightService.Verify(m => m.CreateFlight(mockFlightItem), Times.Once());
        }

        [Fact]
        public async void AddFlight_Returns_BadRequest_When_LandedAt_Less_Than_LaunchedAt()
        {
            // Arrange
            var mockFlightService = new Mock<IFlightsService>();
            mockFlightService.Setup(_ => _.CreateFlight(
                    It.IsAny<FlightItemCommandDto>()
                )
            );
            var mockFlightItem = new FlightItemCommandDto
            {
                Site = "Dalefield",
                LaunchedAt = new DateTime(2021, 10, 1, 10, 00, 00),
                LandedAt = new DateTime(2021, 10, 1, 09, 00, 00),
                Distance = 10,
                Notes = "Test flight"
            };

            var controller = new FlightsController(mockFlightService.Object);

            // Note: when called from unit tests, model parameter binding does not occur - adding error manually
            controller.ControllerContext.ModelState.AddModelError("error",
                "The time the flight landed must be after the launch time.");

            // Act
            var response = await controller.AddFlight(mockFlightItem);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public async void UpdateFlightSite_Returns_Success_When_Site_Updated()
        {
            // Arrange
            var mockFlightService = new Mock<IFlightsService>();
            mockFlightService.Setup(_ => _.UpdateSite(
                        It.IsAny<int>(),
                        It.IsAny<FlightItemSiteUpdateCommandDto>()
                    )
                )
                .ReturnsAsync(true)
                .Verifiable();

            var mockFlightItem = new FlightItemSiteUpdateCommandDto
            {
                Site = "Dalefield"
            };

            var controller = new FlightsController(mockFlightService.Object);

            // Act
            var response = await controller.UpdateFlightSite(1, mockFlightItem);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<NoContentResult>(response);
            mockFlightService.VerifyAll();
        }

        // todo: add further Controller tests
    }
}


