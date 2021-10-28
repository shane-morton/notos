using System;
using System.ComponentModel.DataAnnotations;

using Notos.Database.Models.CommandModels;

namespace Notos.Database.ValidationAttributes
{
    public class LandedAfterLaunchedAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
            $"The time the flight landed must be after the launch time.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var flightItem = (FlightItemCommandDto)validationContext.ObjectInstance;
            var landedAt = (DateTime)value;

            return flightItem.LaunchedAt > landedAt
                ? new ValidationResult(GetErrorMessage())
                : ValidationResult.Success;
        }
    }
}
