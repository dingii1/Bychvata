using Bychvata.Data.Common.Enums;
using Bychvata.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bychvata.Data.Models
{
    public class Guest : BaseDeletableModel<int>
    {
        public Guest()
        {
            this.GuestsReservations = new HashSet<GuestReservation>();
        }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PersonalIdentificationNumber { get; set; }

        public string TelephoneNumber { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public decimal CityTax { get; set; }

        public DateTime BirthDate { get; set; }

        [ForeignKey("Document")]
        public int? DocumentId { get; set; }

        public Document Document { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public virtual IEnumerable<GuestReservation> GuestsReservations { get; set; }
    }
}