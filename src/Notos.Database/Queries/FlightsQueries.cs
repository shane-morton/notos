namespace Notos.Database.Queries
{
    public class FlightsQueries
    {
        public static string GetAllFlights =
            @"SELECT * FROM flight_items";


        public const string GetFlightById =
            @"  SELECT * 
                FROM flight_items
                WHERE id = @id
            ";
    }
}
