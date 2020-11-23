using Bychvata.Data.Common.Enums;
using System.Collections.Generic;

namespace Bychvata.Data.Models
{
    public class Bungalow
    {
        public Bungalow()
        {
            this.Prices = new HashSet<Price>();
        }

        public int Id { get; set; }

        public int Number { get; set; }

        public int Rooms { get; set; }

        public int Beds { get; set; }

        public BungalowType Type { get; set; }

        public bool IsAvailable { get; set; }

        public string Notes { get; set; }

        public virtual IEnumerable<Price> Prices { get; set; }
    }
}