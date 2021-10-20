using System;
using System.ComponentModel.DataAnnotations;

namespace Notos.Database.Models.CommandModels
{
    public class FlightItemLandedAtUpdateCommandDto
    {
        [Required]
        public DateTime LandedAt { get; set; }
    }
}
