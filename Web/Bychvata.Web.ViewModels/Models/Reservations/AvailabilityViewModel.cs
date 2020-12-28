namespace Bychvata.Web.ViewModels.Models.Reservations
{
    using Bychvata.Web.ViewModels.Models.Reservations.BaseModels;

    public class AvailabilityViewModel : ReservationBaseModel
    {
        public bool IsAvailable { get; set; }
    }
}