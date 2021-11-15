namespace Notos.Database.Queries
{
    public class FlightsQueries
    {
        protected FlightsQueries()
        {           
        }

        public const string GetAllFlights =
            @"SELECT * FROM flight_items";


        public const string GetFlightById =
            @"  SELECT * 
                FROM flight_items
                WHERE id = @id
            ";
    }
}
