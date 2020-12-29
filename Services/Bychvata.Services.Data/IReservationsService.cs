namespace Bychvata.Services.Data
{
    using Bychvata.Data.Models;
    using Bychvata.Web.ViewModels.Models.Reservations;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReservationsService
    {
        ICollection<Bungalow> CheckAvailability(AvailabilityBindingModel model);

        Task<int> CreateReservation(ReservationCreateBindingModel model, string userIdClaimValue);

        ICollection<ReservationViewModel> GetReservations(string userIdClaimValue);

        T GetById<T>(int id);

        Task UpdateAsync(int id, ReservationEditBindingModel model);
    }
}