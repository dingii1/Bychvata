using Bychvata.Web.ViewModels.Models.BaseModels;

namespace Bychvata.Web.ViewModels.Models.ViewModels
{
    public class AvailabilityViewModel : ReservationBaseModel
    {
        public bool IsAvailable { get; set; }
    }
}