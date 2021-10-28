using System;
using System.ComponentModel.DataAnnotations;

using Notos.Database.ValidationAttributes;

namespace Notos.Database.Models.CommandModels
{
    public class FlightItemCommandDto
    {
        [Required]
        [StringLength(255)]
        public string Site { get; set; }

        [Required]
        public DateTime LaunchedAt { get; set; }

        [Required]
        [LandedAfterLaunched]
        public DateTime LandedAt { get; set; }

        public long Distance { get; set; }

        public string Notes { get; set; }
    }
}
