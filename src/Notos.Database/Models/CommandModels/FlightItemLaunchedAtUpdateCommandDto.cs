using System;
using System.ComponentModel.DataAnnotations;

namespace Notos.Database.Models.CommandModels
{
    public class FlightItemLaunchedAtUpdateCommandDto
    {
        [Required]
        public DateTime LaunchedAt { get; set; }
    }
}
