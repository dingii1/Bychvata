using Bychvata.Data.Common.Models;

namespace Bychvata.Data.Models
{
    public class BungalowReservation : BaseDeletableModel<int>
    {
        public int BungalowId { get; set; }

        public Bungalow Bungalow { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}