﻿namespace Bychvata.Web.ViewModels.Models.Reservations
{
    using AutoMapper;
    using Bychvata.Data.Models;
    using Bychvata.Services.Mapping;
    using Bychvata.Web.ViewModels.Models.Additions;
    using Bychvata.Web.ViewModels.Models.Guests;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ReservationDetailsViewModel : ReservationViewModel, IMapFrom<Reservation>, IHaveCustomMappings
    {
        public ReservationDetailsViewModel()
        {
            this.Guests = new HashSet<GuestViewModel>();
            this.Additions = new HashSet<AdditionViewModel>();
        }

        [Display(Name = "Бунгало номер")]
        public int? BungalowNumber { get; set; }

        [Display(Name = "Бележки")]
        public string Notes { get; set; }

        [Display(Name = "Добавени гости")]
        public ICollection<GuestViewModel> Guests { get; set; }

        [Display(Name = "Допълнителни услуги")]
        public ICollection<AdditionViewModel> Additions { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Reservation, ReservationDetailsViewModel>()
                .ForMember(x => x.Guests, opt =>
                    opt.MapFrom(x => x.GuestsReservations.Where(y => y.ReservationId == x.Id).Select(z => z.Guest)))
                .ForMember(rdvm => rdvm.Additions, opt =>
                    opt.MapFrom(r => r.ReservationAdditions.Select(ra => ra.Addition)));
        }
    }
}