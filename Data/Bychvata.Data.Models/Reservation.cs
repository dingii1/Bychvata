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
            this.GuestsReservations = new HashSet<GuestReservation>();
            this.ReservationAdditions = new HashSet<ReservationAdditions>();
        }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }

        public string Notes { get; set; }

        public decimal ReservationPrice { get; set; }

        public int? BungalowId { get; set; }

        public Bungalow Bungalow { get; set; }

        public virtual ICollection<GuestReservation> GuestsReservations { get; set; }

        public virtual ICollection<ReservationAdditions> ReservationAdditions { get; set; }
    }
}