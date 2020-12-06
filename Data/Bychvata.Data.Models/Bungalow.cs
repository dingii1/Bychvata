using Bychvata.Data.Common.Enums;
using Bychvata.Data.Common.Models;
using System.Collections.Generic;

namespace Bychvata.Data.Models
{
    public class Bungalow : BaseDeletableModel<int>
    {
        public Bungalow()
        {
            this.Reservations = new HashSet<Reservation>();
            this.DatesAvailable = new HashSet<DateAvailable>();
        }

        public int Number { get; set; }

        public int Rooms { get; set; }

        public int Beds { get; set; }

        public BungalowType Type { get; set; }

        public bool IsAvailable { get; set; }

        public string Notes { get; set; }

        public virtual IEnumerable<Reservation> Reservations { get; set; }

        public virtual IEnumerable<DateAvailable> DatesAvailable { get; set; }
    }
}