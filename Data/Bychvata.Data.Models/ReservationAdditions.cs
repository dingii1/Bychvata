using Bychvata.Data.Common.Models;

namespace Bychvata.Data.Models
{
    public class ReservationAdditions : BaseDeletableModel<int>
    {
        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public int AdditionId { get; set; }

        public Addition Addition { get; set; }
    }
}