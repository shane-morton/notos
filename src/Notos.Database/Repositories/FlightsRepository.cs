using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Notos.Database.Commands;
using Notos.Database.Interfaces;
using Notos.Database.Models.CommandModels;
using Notos.Database.Models.QueryModels;
using Notos.Database.Queries;

namespace Notos.Database.Repositories
{
    public class FlightsRepository : IFlightsRepository
    {
        private readonly ISqlRepository _baseRepository;

        public FlightsRepository(ISqlRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<FlightItemQueryDto>> GetAllFlights()
        {
            return await _baseRepository.QueryAsync<FlightItemQueryDto>(FlightsQueries.GetAllFlights);
        }

        public async Task<FlightItemQueryDto> GetFlightById(int id)
        {
            var flight =
                await _baseRepository.QueryAsync<FlightItemQueryDto>(FlightsQueries.GetFlightById, new { id });

            return flight.FirstOrDefault();
        }

        public async Task<int> CreateFlight(FlightItemCommandDto flightItemCommandDto)
        {
            return await _baseRepository.ExecuteAsync(FlightsCommands.CreateFlight, flightItemCommandDto);
        }

        public async Task<int> UpdateSite(int id, FlightItemSiteUpdateCommandDto updateSiteCommandDto)
        {
            return await _baseRepository.ExecuteAsync(FlightsCommands.UpdateFlightSite,
                new { id, updateSiteCommandDto.Site });
        }

        public async Task<int> UpdateLaunchedAt(int id, FlightItemLaunchedAtUpdateCommandDto updateLaunchedAtCommandDto)
        {
            return await _baseRepository.ExecuteAsync(FlightsCommands.UpdateFlightLaunchedAt,
                new { id, updateLaunchedAtCommandDto.LaunchedAt });
        }

        public async Task<int> UpdateLandedAt(int id, FlightItemLandedAtUpdateCommandDto updateLandedAtCommandDto)
        {
            return await _baseRepository.ExecuteAsync(FlightsCommands.UpdateFlightLandedAt,
                new { id, updateLandedAtCommandDto.LandedAt });
        }

        public async Task<int> UpdateDistance(int id, FlightItemDistanceUpdateCommandDto updateDistanceCommandDto)
        {
            return await _baseRepository.ExecuteAsync(FlightsCommands.UpdateFlightDistance,
                new { id, updateDistanceCommandDto.Distance });
        }

        public async Task<int> UpdateNotes(int id, FlightItemNotesUpdateCommandDto updateNotesCommandDto)
        {
            return await _baseRepository.ExecuteAsync(FlightsCommands.UpdateFlightNotes,
                new { id, updateNotesCommandDto.Notes });
        }

        public async Task<int> DeleteFlight(int id)
        {
            return await _baseRepository.ExecuteAsync(FlightsCommands.DeleteFlight, new { id });
        }
    }
}
