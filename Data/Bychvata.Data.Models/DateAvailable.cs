using Bychvata.Data.Common.Models;
using System;

namespace Bychvata.Data.Models
{
    public class DateAvailable : BaseDeletableModel<int>
    {
        public DateAvailable()
        {
            this.IsAvailable = true;
        }

        public DateTime Date { get; set; }

        public bool IsAvailable { get; set; }

        public int BungalowId { get; set; }

        public Bungalow Bungalow { get; set; }
    }
}