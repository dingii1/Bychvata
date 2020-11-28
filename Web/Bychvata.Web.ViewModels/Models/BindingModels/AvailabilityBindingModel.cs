using Bychvata.Web.ViewModels.Models.BaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bychvata.Web.ViewModels.Models.BindingModels
{
    public class AvailabilityBindingModel : ReservationBaseModel, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Arrival > this.Departure)
            {
                yield return new ValidationResult("Датата на пристигане трябва да бъде преди датата на заминаване.");
            }
        }
    }
}