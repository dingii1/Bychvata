using Bychvata.Data.Common.Enums;
using Bychvata.Data.Common.Models;
using System.Collections.Generic;

namespace Bychvata.Data.Models
{
    public class Bungalow : BaseDeletableModel<int>
    {
        public Bungalow()
        {
            this.BungalowsReservations = new HashSet<BungalowReservation>();
            this.Prices = new HashSet<Price>();
            this.DatesAvailable = new HashSet<DateAvailable>();
        }

        public int Number { get; set; }

        public int Rooms { get; set; }

        public int Beds { get; set; }

        public BungalowType Type { get; set; }

        public bool IsAvailable { get; set; }

        public string Notes { get; set; }

        public virtual IEnumerable<BungalowReservation> BungalowsReservations { get; set; }

        public virtual IEnumerable<Price> Prices { get; set; }

        public virtual IEnumerable<DateAvailable> DatesAvailable { get; set; }
    }
}