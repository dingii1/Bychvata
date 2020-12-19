using AutoMapper;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace Bychvata.Web.ViewModels.Models.ViewModels
{
    public class ReservationDetailsViewModel : ReservationViewModel, IMapFrom<Reservation>, IHaveCustomMappings
    {
        public ReservationDetailsViewModel()
        {
            this.Guests = new HashSet<Guest>();
            this.Additions = new HashSet<Addition>();
        }

        public int? BungalowNumber { get; set; }

        public string Notes { get; set; }

        public ICollection<Guest> Guests { get; set; }

        public ICollection<Addition> Additions { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Reservation, ReservationDetailsViewModel>()
                .ForMember(x => x.Guests, opt =>
                    opt.MapFrom(x => x.GuestsReservations.Where(y => y.ReservationId == x.Id).Select(z => z.Guest)));
        }
    }
}