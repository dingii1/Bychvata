namespace Bychvata.Web.ViewModels.Models.Guests
{
    using Bychvata.Data.Common.Enums;
    using Bychvata.Data.Models;
    using Bychvata.Services.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GuestAddBindingModel : IMapTo<Guest>
    {
        public int ReservationId { get; set; }

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

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public DocumentType DocumentType { get; set; }

        public string DocumentNumber { get; set; }
    }
}