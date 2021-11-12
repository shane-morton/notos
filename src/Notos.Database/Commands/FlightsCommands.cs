namespace Notos.Database.Commands
{
    public class FlightsCommands
    {
        protected FlightsCommands()
        {
        }
        public const string CreateFlight =
            @"  INSERT INTO flight_items (site, launchedat, landedat, distance, notes)
                VALUES (@site, @launchedAt, @landedAt, @distance, @notes)
            ";

        public const string UpdateFlightSite =
            @"  UPDATE flight_items
                SET site=@site
                WHERE id=@id
            ";

        public const string UpdateFlightLaunchedAt =
            @"  UPDATE flight_items
                SET launchedAt=@launchedAt
                WHERE id=@id
            ";

        public const string UpdateFlightLandedAt =
            @"  UPDATE flight_items
                SET landedAt=@landedAt
                WHERE id=@id
            ";

        public const string UpdateFlightDistance =
            @"  UPDATE flight_items
                SET distance=@distance
                WHERE id=@id
            ";

        public const string UpdateFlightNotes =
            @"  UPDATE flight_items
                SET notes=@notes
                WHERE id=@id
            ";

        public const string DeleteFlight =
            @"  DELETE FROM flight_items
                WHERE id=@id
            ";
    }
}
