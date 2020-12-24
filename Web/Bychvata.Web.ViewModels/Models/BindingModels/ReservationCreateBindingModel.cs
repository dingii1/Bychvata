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
            this.Additions = new List<AdditionBindingModel>();
        }

        public int? BungalowId { get; set; }

        public string Notes { get; set; }

        public IList<AdditionBindingModel> Additions { get; set; }
    }
}