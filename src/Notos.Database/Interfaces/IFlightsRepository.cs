using System.Collections.Generic;
using System.Threading.Tasks;

using Notos.Database.Models.CommandModels;
using Notos.Database.Models.QueryModels;

namespace Notos.Database.Interfaces
{
    public interface IFlightsRepository
    {
        Task<IEnumerable<FlightItemQueryDto>> GetAllFlights();
        Task<FlightItemQueryDto> GetFlightById(int id);
        Task<int> CreateFlight(FlightItemCommandDto flightItemCommandDto);
        Task<int> UpdateSite(int id, FlightItemSiteUpdateCommandDto updateSiteCommandDto);
        Task<int> UpdateLaunchedAt(int id, FlightItemLaunchedAtUpdateCommandDto updateLaunchedAtCommandDto);
        Task<int> UpdateLandedAt(int id, FlightItemLandedAtUpdateCommandDto updateLandedAtCommandDto);
        Task<int> UpdateDistance(int id, FlightItemDistanceUpdateCommandDto updateDistanceCommandDto);
        Task<int> UpdateNotes(int id, FlightItemNotesUpdateCommandDto updateNotesCommandDto);
        Task<int> DeleteFlight(int id);
    }
}