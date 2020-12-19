using AutoMapper;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using Bychvata.Web.ViewModels.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Bychvata.Web.ViewModels.Models.BindingModels
{
    public class ReservationEditBindingModel : ReservationCreateBindingModel, IMapTo<Reservation>, IMapFrom<Reservation>, IHaveCustomMappings
    {
        public ReservationEditBindingModel()
        {
            this.Guests = new HashSet<GuestViewModel>();
        }

        public int Id { get; set; }

        public ICollection<GuestViewModel> Guests { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Reservation, ReservationEditBindingModel>()
                .ForMember(x => x.Guests, opt =>
                    opt.MapFrom(x => x.GuestsReservations.Where(y => y.ReservationId == x.Id).Select(z => z.Guest)));
        }
    }
}