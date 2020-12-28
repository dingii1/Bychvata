namespace Bychvata.Data.Models
{
    public class ReservationAdditions
    {
        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public int AdditionId { get; set; }

        public Addition Addition { get; set; }
    }
}