namespace Bychvata.Web.ViewModels.Models.Guests
{
    using Bychvata.Data.Common.Enums;
    using Bychvata.Data.Models;
    using Bychvata.Services.Mapping;
    using System;

    public class GuestAddBindingModel : IMapTo<Guest>
    {
        public int ReservationId { get; set; }

        public string Nationality { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PersonalIdentificationNumber { get; set; }

        public string TelephoneNumber { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public DocumentType DocumentType { get; set; }

        public string DocumentNumber { get; set; }
    }
}