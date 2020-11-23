using System;

namespace Bychvata.Web.ViewModels.Models.ViewModels
{
    public class ReservationViewModel
    {
        public DateTime CreatedOn { get; set; }

        public int BungalowNumber { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }

        public string Notes { get; set; }

        public decimal ReservationPrice { get; set; }
    }
}