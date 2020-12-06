using Bychvata.Data.Models;
using Bychvata.Services.Mapping;

namespace Bychvata.Web.ViewModels.Models.ViewModels
{
    public class GuestViewModel : IMapFrom<Guest>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TelephoneNumber { get; set; }
    }
}