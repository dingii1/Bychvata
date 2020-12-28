namespace Bychvata.Web.ViewModels.Models.Reservations
{
    using Bychvata.Data.Models;
    using Bychvata.Services.Mapping;
    using Bychvata.Web.ViewModels.Models.Additions;
    using Bychvata.Web.ViewModels.Models.Reservations.BaseModels;
    using System.Collections.Generic;

    public class ReservationCreateBindingModel : ReservationBaseModel, IMapFrom<Reservation>
    {
        public ReservationCreateBindingModel()
        {
            Additions = new List<AdditionBindingModel>();
        }

        public int? BungalowId { get; set; }

        public string Notes { get; set; }

        public IList<AdditionBindingModel> Additions { get; set; }
    }
}