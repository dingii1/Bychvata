using Bychvata.Data.Models;
using Bychvata.Web.ViewModels.Models.BindingModels;
using Bychvata.Web.ViewModels.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bychvata.Services.Data
{
    public interface IReservationsService
    {
        ICollection<Bungalow> CheckAvailability(AvailabilityBindingModel model);

        Task<int> CreateReservation(ReservationCreateBindingModel model, string userIdClaimValue);

        ICollection<ReservationViewModel> GetReservations(string userIdClaimValue);

        ReservationDetailsViewModel GetById(int id);
    }
}