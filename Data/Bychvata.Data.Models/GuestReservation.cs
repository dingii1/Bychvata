using Bychvata.Data.Common.Models;

namespace Bychvata.Data.Models
{
    public class GuestReservation : BaseDeletableModel<int>
    {
        public int GuestId { get; set; }

        public Guest Guest { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}