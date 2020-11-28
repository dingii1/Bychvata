using Bychvata.Data.Common.Models;
using System;

namespace Bychvata.Data.Models
{
    public class Price : BaseDeletableModel<int>
    {
        public DateTime Date { get; set; }

        public double? DiscountPercent { get; set; }

        public decimal Cost { get; set; }

        public int BungalowId { get; set; }

        public Bungalow Bungalow { get; set; }
    }
}