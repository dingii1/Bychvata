using Bychvata.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bychvata.Data.Models
{
    public class Reservation : BaseDeletableModel<int>
    {
        public Reservation()
        {
            this.BungalowsReservations = new HashSet<BungalowReservation>();
            this.GuestsReservations = new HashSet<GuestReservation>();
            this.Additions = new HashSet<Addition>();
        }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }

        public string Notes { get; set; }

        public decimal ReservationPrice { get; set; }

        public virtual IEnumerable<BungalowReservation> BungalowsReservations { get; set; }

        public virtual IEnumerable<GuestReservation> GuestsReservations { get; set; }

        public virtual IEnumerable<Addition> Additions { get; set; }
    }
}