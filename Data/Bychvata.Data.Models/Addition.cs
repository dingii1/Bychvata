using Bychvata.Data.Common.Enums;
using Bychvata.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bychvata.Data.Models
{
    public class Addition : BaseDeletableModel<int>
    {
        public Addition()
        {
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        public AdditionType Name { get; set; }

        public decimal Value { get; set; }

        public string Notes { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}