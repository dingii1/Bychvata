namespace Bychvata.Web.ViewModels.Models.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AvailabilityBindingModel : IValidatableObject
    {
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Arrival { get; set; } = DateTime.Now;

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Departure { get; set; } = DateTime.Now.AddDays(1);

        public bool IsAvailable { get; set; }

        public bool ShouldShowAvailabilityDetails { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Arrival.Date < DateTime.Now.Date)
            {
                yield return new ValidationResult("Не може да бъде направена резервация за предходна дата.", new List<string>() { Arrival.ToString() });
            }

            if (this.Arrival >= this.Departure)
            {
                yield return new ValidationResult("Датата на пристигане трябва да бъде преди датата на заминаване.", new List<string>() { Arrival.ToString(), Departure.ToString() });
            }
        }
    }
}