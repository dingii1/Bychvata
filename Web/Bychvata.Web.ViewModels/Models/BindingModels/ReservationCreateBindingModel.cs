using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using System;
using System.Collections.Generic;

namespace Bychvata.Web.ViewModels.Models.BindingModels
{
    public class ReservationCreateBindingModel : IMapTo<Reservation>
    {
        public int? BungalowId { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }

        public string Notes { get; set; }

        public IEnumerable<Addition> Additions { get; set; }
    }
}