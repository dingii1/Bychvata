using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bychvata.Web.ViewModels.Models.BindingModels
{
    public class AvailabilityBindingModel : IValidatableObject
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (From > To)
            {
                yield return new ValidationResult("Датата на пристигане трябва да бъде преди датата на заминаване.");
            }
        }
    }
}