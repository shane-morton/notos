using System.ComponentModel.DataAnnotations;

namespace Notos.Database.Models.CommandModels
{
    public class FlightItemDistanceUpdateCommandDto
    {
        [Required]
        public int Distance { get; set; }
    }
}
