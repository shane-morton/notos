using System.Collections.Generic;
using System.Threading.Tasks;

using Notos.Database.Interfaces;
using Notos.Database.Models.CommandModels;
using Notos.Database.Models.QueryModels;
using Notos.Service.Interfaces;

namespace Notos.Service
{
    public class FlightsService : IFlightsService
    {
        private readonly IFlightsRepository _flightsRepository;

        public FlightsService(IFlightsRepository flightsRepository)
        {
            _flightsRepository = flightsRepository;
        }

        public async Task<IEnumerable<FlightItemQueryDto>> GetAllFlights()
        {
            return await _flightsRepository.GetAllFlights();
        }

        public async Task<FlightItemQueryDto> GetFlightById(int id)
        {
            var response = await _flightsRepository.GetFlightById(id);

            return response;
        }

        public async Task<bool> CreateFlight(FlightItemCommandDto flightItemCommandDto)
        {
            var response = await _flightsRepository.CreateFlight(flightItemCommandDto);

            return response == 1;
        }

        public async Task<bool> UpdateSite(int id, FlightItemSiteUpdateCommandDto updateSiteCommandDto)
        {
            var response = await _flightsRepository.UpdateSite(id, updateSiteCommandDto);

            return response == 1;
        }

        public async Task<bool> UpdateLaunchedAt(int id, FlightItemLaunchedAtUpdateCommandDto updateLaunchedAtCommandDto)
        {
            var response = await _flightsRepository.UpdateLaunchedAt(id, updateLaunchedAtCommandDto);

            return response == 1;
        }

        public async Task<bool> UpdateLandedAt(int id, FlightItemLandedAtUpdateCommandDto updateLandedAtCommandDto)
        {
            var response = await _flightsRepository.UpdateLandedAt(id, updateLandedAtCommandDto);

            return response == 1;
        }

        public async Task<bool> UpdateDistance(int id, FlightItemDistanceUpdateCommandDto updateDistanceCommandDto)
        {
            var response = await _flightsRepository.UpdateDistance(id, updateDistanceCommandDto);

            return response == 1;
        }

        public async Task<bool> UpdateNotes(int id, FlightItemNotesUpdateCommandDto updateNotesCommandDto)
        {
            var response = await _flightsRepository.UpdateNotes(id, updateNotesCommandDto);

            return response == 1;
        }

        public async Task<bool> DeleteFlight(int id)
        {
            var response = await _flightsRepository.DeleteFlight(id);

            return response == 1;
        }
    }
}
