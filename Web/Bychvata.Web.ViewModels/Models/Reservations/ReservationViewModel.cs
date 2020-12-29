namespace Bychvata.Web.ViewModels.Models.Reservations
{
    using Bychvata.Data.Models;
    using Bychvata.Services.Mapping;
    using Bychvata.Web.ViewModels.Models.Reservations.BaseModels;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReservationViewModel : ReservationBaseModel, IMapFrom<Reservation>
    {
        public int Id { get; set; }

        [Display(Name = "Създадена на")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Цена")]
        public decimal ReservationPrice { get; set; }

        public int GuestsReservationsCount { get; set; }
    }
}