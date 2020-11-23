using Bychvata.Data.Common.Enums;
using Bychvata.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bychvata.Data.Models
{
    public class Bungalow : BaseDeletableModel<int>
    {
        public Bungalow()
        {
            this.Prices = new HashSet<Price>();
            this.DatesAvailable = new HashSet<DateAvailable>();
        }

        public int Id { get; set; }

        public int Number { get; set; }

        public int Rooms { get; set; }

        public int Beds { get; set; }

        public BungalowType Type { get; set; }

        public bool IsAvailable { get; set; }

        public string Notes { get; set; }

        [ForeignKey("Reservation")]
        public int? ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public virtual IEnumerable<Price> Prices { get; set; }

        public virtual IEnumerable<DateAvailable> DatesAvailable { get; set; }
    }
}