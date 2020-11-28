using Bychvata.Data.Common.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bychvata.Data.Models
{
    public class DateAvailable : BaseDeletableModel<int>
    {
        public DateTime Date { get; set; }

        public bool IsAvailable { get; set; }

        [ForeignKey("Bungalow")]
        public int BungalowId { get; set; }

        public Bungalow Bungalow { get; set; }
    }
}