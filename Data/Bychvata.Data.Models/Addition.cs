using Bychvata.Data.Common.Enums;
using Bychvata.Data.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Bychvata.Data.Models
{
    public class Addition : BaseDeletableModel<int>
    {
        [Required]
        public AdditionType Name { get; set; }

        public decimal Value { get; set; }

        public string Notes { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public int? BungalowId { get; set; }

        public Bungalow Bungalow { get; set; }
    }
}