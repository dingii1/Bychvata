using Bychvata.Data.Models;
using Bychvata.Web.ViewModels.Models.BindingModels;
using System.Threading.Tasks;

namespace Bychvata.Services.Data
{
    public interface IReservationsService
    {
        Task<bool> CheckAvailability(AvailabilityBindingModel model);

        Task<int> CreateReservation(ReservationCreateBindingModel model, ApplicationUser user);
    }
}