using System.ComponentModel.DataAnnotations;

namespace Notos.Database.Models.CommandModels
{
    public class FlightItemNotesUpdateCommandDto
    {
        [Required]
        public string Notes { get; set; }
    }
}
