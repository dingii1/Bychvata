using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using Bychvata.Web.ViewModels.Models.BaseModels;
using System.Collections.Generic;

namespace Bychvata.Web.ViewModels.Models.BindingModels
{
    public class ReservationCreateBindingModel : ReservationBaseModel, IMapTo<Reservation>
    {
        public ReservationCreateBindingModel()
        {
            this.Additions = new HashSet<Addition>();
        }

        public int? BungalowId { get; set; }

        public string Notes { get; set; }

        public ICollection<Addition> Additions { get; set; }
    }
}