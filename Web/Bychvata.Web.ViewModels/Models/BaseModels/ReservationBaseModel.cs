using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bychvata.Web.ViewModels.Models.BaseModels
{
    public class ReservationBaseModel : IValidatableObject
    {
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Arrival { get; set; } = DateTime.Now;

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Departure { get; set; } = DateTime.Now.AddDays(1);

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Arrival < DateTime.Now)
            {
                yield return new ValidationResult("Не може да бъде направена резервация за предходна дата.", new List<string>() { this.Arrival.ToString() });
            }

            if (this.Arrival > this.Departure)
            {
                yield return new ValidationResult("Датата на пристигане трябва да бъде преди датата на заминаване.", new List<string>() { this.Arrival.ToString(), this.Departure.ToString() });
            }
        }
    }
}