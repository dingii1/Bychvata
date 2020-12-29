namespace Bychvata.Web.ViewModels.Models.Reservations.BaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ReservationBaseModel : IValidatableObject
    {
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Пристигане")]
        public DateTime Arrival { get; set; } = DateTime.Now;

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Заминаване")]
        public DateTime Departure { get; set; } = DateTime.Now.AddDays(1);

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Arrival < DateTime.Today)
            {
                yield return new ValidationResult("Не може да бъде направена резервация за предходна дата.", new List<string>() { nameof(this.Arrival) });
            }

            if (this.Arrival > this.Departure)
            {
                yield return new ValidationResult("Датата на пристигане трябва да бъде преди датата на заминаване.", new List<string>() { nameof(this.Arrival), nameof(this.Departure) });
            }
        }
    }
}