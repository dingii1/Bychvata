namespace Bychvata.Web.ViewModels.Models.Reservations
{
    using Bychvata.Data.Models;
    using Bychvata.Services.Mapping;
    using Bychvata.Web.ViewModels.Models.Reservations.BaseModels;
    using System;

    public class ReservationViewModel : ReservationBaseModel, IMapFrom<Reservation>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal ReservationPrice { get; set; }

        public int GuestsReservationsCount { get; set; }
    }
}