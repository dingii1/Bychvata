using Bychvata.Data.Common.Models;
using System.Collections.Generic;

namespace Bychvata.Data.Models
{
    public class Price : BaseDeletableModel<int>
    {
        public Price()
        {
            this.DiscountPercent = 0;
            this.DatesAvailable = new HashSet<DateAvailable>();
        }

        public decimal DiscountPercent { get; set; }

        public decimal Cost { get; set; }

        public decimal TotalPrice => this.Cost - (this.DiscountPercent / 100 * this.Cost);

        public IEnumerable<DateAvailable> DatesAvailable { get; set; }
    }
}