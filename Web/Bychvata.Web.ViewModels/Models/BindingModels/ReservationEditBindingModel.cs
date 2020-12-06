using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using Bychvata.Web.ViewModels.Models.ViewModels;
using System.Collections.Generic;

namespace Bychvata.Web.ViewModels.Models.BindingModels
{
    public class ReservationEditBindingModel : ReservationCreateBindingModel, IMapTo<Reservation>
    {
        public ReservationEditBindingModel()
        {
            this.Guests = new HashSet<GuestViewModel>();
        }

        public int Id { get; set; }

        public ICollection<GuestViewModel> Guests { get; set; }
    }
}