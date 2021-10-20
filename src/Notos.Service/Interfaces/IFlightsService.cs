using System.Collections.Generic;
using System.Threading.Tasks;

using Notos.Database.Models.CommandModels;
using Notos.Database.Models.QueryModels;


namespace Notos.Service.Interfaces
{
    public interface IFlightsService
    {
        Task<IEnumerable<FlightItemQueryDto>> GetAllFlights();
        Task<FlightItemQueryDto> GetFlightById(int id);
        Task<bool> CreateFlight(FlightItemCommandDto flightItemCommandDto);
        Task<bool> UpdateSite(int id, FlightItemSiteUpdateCommandDto updateSiteCommandDto);
        Task<bool> UpdateLaunchedAt(int id, FlightItemLaunchedAtUpdateCommandDto updateLaunchedAtCommandDto);
        Task<bool> UpdateLandedAt(int id, FlightItemLandedAtUpdateCommandDto updateLandedAtCommandDto);
        Task<bool> UpdateDistance(int id, FlightItemDistanceUpdateCommandDto updateDistanceCommandDto);
        Task<bool> UpdateNotes(int id, FlightItemNotesUpdateCommandDto updateNotesCommandDto);
        Task<bool> DeleteFlight(int id);
    }
}