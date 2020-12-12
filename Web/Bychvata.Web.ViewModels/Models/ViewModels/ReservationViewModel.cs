using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using Bychvata.Web.ViewModels.Models.BaseModels;
using System;

namespace Bychvata.Web.ViewModels.Models.ViewModels
{
    public class ReservationViewModel : ReservationBaseModel, IMapFrom<Reservation>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal ReservationPrice { get; set; }

        public int GuestsReservationsCount { get; set; }
    }
}