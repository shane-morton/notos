using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Notos.Database.Models.CommandModels;
using Notos.Database.Models.QueryModels;
using Notos.Service.Interfaces;

namespace Notos.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightsService _flightsService;

        public FlightsController(IFlightsService flightsService)
        {
            _flightsService = flightsService;
        }

        [HttpGet]
        public async Task<IEnumerable<FlightItemQueryDto>> GetAllFlights()
        {
            return await _flightsService.GetAllFlights();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlightItemQueryDto>> GetFlightById(int id)
        {
            var response = await _flightsService.GetFlightById(id);
            if (response == null)
                return new NotFoundResult();

            return response;
        }

        [HttpPost]
        public async Task<ActionResult> AddFlight([FromBody] FlightItemCommandDto flightItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _flightsService.CreateFlight(flightItem);

            return CreatedAtAction(ControllerContext.ActionDescriptor.ActionName,
                ControllerContext.ActionDescriptor.RouteValues, string.Empty);
        }

        [HttpPut("{id}/updateSite")]
        public async Task<ActionResult> UpdateFlightSite(int id, [FromBody] FlightItemSiteUpdateCommandDto flightItem)
        {
            var response = await _flightsService.UpdateSite(id, flightItem);

            return response ? NoContent() : (ActionResult)new NotFoundResult();
        }

        [HttpPut("{id}/updateLaunchedAt")]
        public async Task<ActionResult> UpdateFlightLaunchedAt(int id, [FromBody] FlightItemLaunchedAtUpdateCommandDto flightItem)
        {
            var response = await _flightsService.UpdateLaunchedAt(id, flightItem);

            return response ? NoContent() : (ActionResult)new NotFoundResult();
        }

        [HttpPut("{id}/updateLandedAt")]
        public async Task<ActionResult> UpdateFlightLandedAt(int id, [FromBody] FlightItemLandedAtUpdateCommandDto flightItem)
        {
            var response = await _flightsService.UpdateLandedAt(id, flightItem);

            return response ? NoContent() : (ActionResult)new NotFoundResult();
        }

        [HttpPut("{id}/updateDistance")]
        public async Task<ActionResult> UpdateFlightDistance(int id, [FromBody] FlightItemDistanceUpdateCommandDto flightItem)
        {
            var response = await _flightsService.UpdateDistance(id, flightItem);

            return response ? NoContent() : (ActionResult)new NotFoundResult();
        }

        [HttpPut("{id}/updateNotes")]
        public async Task<ActionResult> UpdateFlightNotes(int id, [FromBody] FlightItemNotesUpdateCommandDto flightItem)
        {
            var response = await _flightsService.UpdateNotes(id, flightItem);

            return response ? NoContent() : (ActionResult)new NotFoundResult();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFlight(int id)
        {
            var response = await _flightsService.DeleteFlight(id);

            return response ? NoContent() : (ActionResult)new NotFoundResult();
        }
    }
}
