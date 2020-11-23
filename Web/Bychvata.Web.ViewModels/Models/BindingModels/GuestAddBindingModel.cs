using Bychvata.Data.Models;
using System;

namespace Bychvata.Web.ViewModels.Models.BindingModels
{
    public class GuestAddBindingModel
    {
        public string Nationality { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PersonalIdentificationNumber { get; set; }

        public string TelephoneNumber { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public Document Document { get; set; }
    }
}