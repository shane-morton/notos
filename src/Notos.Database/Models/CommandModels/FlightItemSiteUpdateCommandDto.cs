using System.ComponentModel.DataAnnotations;

namespace Notos.Database.Models.CommandModels
{
    public class FlightItemSiteUpdateCommandDto
    {
        [Required]
        public string Site { get; set; }
    }
}
