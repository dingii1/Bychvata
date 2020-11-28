using Bychvata.Data.Common.Repositories;
using Bychvata.Data.Models;
using Bychvata.Web.ViewModels.Models.BaseModels;
using Bychvata.Web.ViewModels.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bychvata.Services.Data
{
    public class ReservationsService : IReservationsService
    {
        private readonly IDeletableEntityRepository<Bungalow> bungalowsRepository;
        private readonly IDeletableEntityRepository<Reservation> reservationsRepository;

        public ReservationsService(IDeletableEntityRepository<Bungalow> bungalowsRepository, IDeletableEntityRepository<Reservation> reservationsRepository)
        {
            this.bungalowsRepository = bungalowsRepository;
            this.reservationsRepository = reservationsRepository;
        }

        public async Task<bool> CheckAvailability(AvailabilityBindingModel model)
        {
            var bungalow = await this.CheckReservationsDate(model);

            return bungalow != null ? true : false;
        }

        public async Task<int> CreateReservation(ReservationCreateBindingModel model, ApplicationUser user)
        {
            var reservationDates = new HashSet<DateTime>();
            var reservationLength = (model.Departure.Date - model.Arrival.Date).Days;

            for (int i = 0; i < reservationLength; i++)
            {
                reservationDates.Add(model.Arrival.AddDays(i));
            }

            var bungalow = this.bungalowsRepository.All()
                .Where(x => x.IsAvailable == true && x.DatesAvailable.All(s => reservationDates.Contains(s.Date)))
                .FirstOrDefault();

            if (bungalow != null)
            {
                foreach (var date in bungalow.DatesAvailable)
                {
                    if (reservationDates.Contains(date.Date))
                    {
                        date.IsAvailable = false;
                    }
                }

                await this.bungalowsRepository.SaveChangesAsync();

                var reservation = new Reservation
                {
                    ApplicationUserId = user.Id,
                    Arrival = model.Arrival,
                    Departure = model.Departure,
                    Notes = model.Notes,
                    ReservationPrice = 100,
                };

                await this.reservationsRepository.SaveChangesAsync();

                return reservation.Id;
            }
            else
            {
                return -1;
            }
        }

        private async Task<Bungalow> CheckReservationsDate(ReservationBaseModel model)
        {
            var reservationDates = new HashSet<DateTime>();
            var reservationLength = (model.Departure.Date - model.Arrival.Date).Days;

            for (int i = 0; i < reservationLength; i++)
            {
                reservationDates.Add(model.Arrival.AddDays(i));
            }

            var bungalow = this.bungalowsRepository.All()
                .Where(x => x.IsAvailable == true && x.DatesAvailable.All(s => reservationDates.Contains(s.Date)))
                .FirstOrDefault();

            return bungalow;
        }
    }
}