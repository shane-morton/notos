using System;

namespace Notos.Database.Models.QueryModels
{
    public class FlightItemQueryDto
    {
        public int Id { get; set; }
        public string Site { get; set; }
        public DateTime LaunchedAt { get; set; }
        public DateTime LandedAt { get; set; }
        public int Distance { get; set; }
        public string Notes { get; set; }

    }
}
