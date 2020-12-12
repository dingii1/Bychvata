using AutoMapper;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using System.Collections.Generic;

namespace Bychvata.Web.ViewModels.Models.ViewModels
{
    public class ReservationDetailsViewModel : ReservationViewModel, IMapFrom<Reservation>
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
    }
}