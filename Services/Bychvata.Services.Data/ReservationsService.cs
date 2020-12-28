using Bychvata.Data.Common.Repositories;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using Bychvata.Web.ViewModels.Models.Reservations;
using Microsoft.EntityFrameworkCore;
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
        private readonly IDeletableEntityRepository<Guest> guestsRepository;

        public ReservationsService(IDeletableEntityRepository<Bungalow> bungalowsRepository, IDeletableEntityRepository<Reservation> reservationsRepository, IDeletableEntityRepository<Guest> guestsRepository)
        {
            this.bungalowsRepository = bungalowsRepository;
            this.reservationsRepository = reservationsRepository;
            this.guestsRepository = guestsRepository;
        }

        public ICollection<Bungalow> CheckAvailability(AvailabilityBindingModel model)
        {
            var reservationDates = new HashSet<DateTime>();
            var reservationLength = (model.Departure.Date - model.Arrival.Date).Days;

            for (int i = 0; i < reservationLength; i++)
            {
                reservationDates.Add(model.Arrival.AddDays(i));
            }

            return this.bungalowsRepository.All()
                .Include(b => b.DatesAvailable.Where(d => d.IsAvailable == true && d.IsDeleted == false))
                .ToList()
                .Where(b => b.IsAvailable == true && reservationDates.All(d => b.DatesAvailable.Any(date => d == date.Date)))
                .ToList();
        }

        public async Task<int> CreateReservation(ReservationCreateBindingModel model, string userIdClaimValue)
        {
            var reservationDates = new HashSet<DateTime>();
            var reservationLength = (model.Departure.Date - model.Arrival.Date).Days;

            for (int i = 0; i < reservationLength; i++)
            {
                reservationDates.Add(model.Arrival.AddDays(i));
            }

            ICollection<Bungalow> bungalows = this.bungalowsRepository.All()
                .Include(b => b.DatesAvailable.Where(d => d.IsAvailable == true && d.IsDeleted == false))
                .ThenInclude(b => b.Price)
                .ToList()
                .Where(b => b.IsAvailable == true && reservationDates.All(d => b.DatesAvailable.Any(date => d == date.Date)))
                .ToList();

            Bungalow bungalow = new Bungalow();

            if (bungalows.Count > 0)
            {
                bungalow = bungalows.FirstOrDefault();
            }
            else
            {
                return -1;
            }

            Reservation reservation = new Reservation
            {
                ApplicationUserId = userIdClaimValue,
                Arrival = model.Arrival,
                Departure = model.Departure,
                Notes = model.Notes,
                ReservationPrice = 0,
                BungalowId = bungalow.Id,
            };

            foreach (var date in bungalow.DatesAvailable)
            {
                if (reservationDates.Contains(date.Date))
                {
                    date.IsAvailable = false;
                    reservation.ReservationPrice += date.Price.TotalPrice;
                }
            }

            foreach (var addition in model.Additions)
            {
                if (addition.IsIncluded)
                {
                    reservation.ReservationPrice += addition.Price;
                }
            }

            await this.bungalowsRepository.SaveChangesAsync();

            await this.reservationsRepository.AddAsync(reservation);
            await this.reservationsRepository.SaveChangesAsync();

            return reservation.Id;
        }

        public T GetById<T>(int id)
        {
            return this.reservationsRepository.AllAsNoTracking()
                .Include(r => r.GuestsReservations)
                .ThenInclude(gr => gr.Guest)
                .Include(r => r.ReservationAdditions)
                .ThenInclude(ra => ra.Addition)
                .Where(r => r.Id == id)
                .To<T>()
                .FirstOrDefault();
        }

        public async Task UpdateAsync(int reservationId, ReservationEditBindingModel model)
        {
            Reservation reservation = this.reservationsRepository
                .All()
                .Include(r => r.ReservationAdditions)
                .ThenInclude(ra => ra.Addition)
                .Where(r => r.Id == reservationId)
                .FirstOrDefault();

            reservation.Notes = model.Notes;

            reservation.ReservationAdditions.ToList().Clear();

            foreach (var addition in model.Additions)
            {
                if (addition.IsIncluded)
                {
                    reservation.ReservationAdditions.Append(new ReservationAdditions
                    {
                        AdditionId = addition.Id,
                        ReservationId = reservation.Id,
                    });
                }
            }

            this.reservationsRepository.Update(reservation);

            await this.reservationsRepository.SaveChangesAsync();
        }

        public ICollection<ReservationViewModel> GetReservations(string userIdClaimValue)
        {
            return this.reservationsRepository
                .AllAsNoTracking()
                .Where(r => r.ApplicationUser.Id == userIdClaimValue)
                .Include(r => r.Bungalow)
                .To<ReservationViewModel>()
                .ToList();
        }
    }
}