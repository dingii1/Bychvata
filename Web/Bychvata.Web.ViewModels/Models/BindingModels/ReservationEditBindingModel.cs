using AutoMapper;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using Bychvata.Web.ViewModels.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bychvata.Web.ViewModels.Models.BindingModels
{
    public class ReservationEditBindingModel : IMapTo<Reservation>, IMapFrom<Reservation>, IHaveCustomMappings
    {
        public ReservationEditBindingModel()
        {
            this.Guests = new HashSet<GuestViewModel>();
        }

        public int Id { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }

        public decimal Price { get; set; }

        public string Notes { get; set; }

        public IList<AdditionBindingModel> Additions { get; set; }

        public ICollection<GuestViewModel> Guests { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Reservation, ReservationEditBindingModel>()
                .ForMember(x => x.Guests, opt =>
                    opt.MapFrom(r => r.GuestsReservations.Where(gr => gr.ReservationId == r.Id).Select(x => x.Guest)))
                .ForMember(x => x.Price, opt =>
                    opt.MapFrom(r => r.ReservationPrice));
        }
    }
}