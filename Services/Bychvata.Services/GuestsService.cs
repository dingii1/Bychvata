using Bychvata.Data.Common.Repositories;
using Bychvata.Data.Models;
using Bychvata.Web.ViewModels.Models.BindingModels;
using System;
using System.Threading.Tasks;

namespace Bychvata.Services
{
    public class GuestsService : IGuestsService
    {
        private readonly IDeletableEntityRepository<Guest> guestsRepository;
        private readonly IDeletableEntityRepository<GuestReservation> guestsReservationsRepository;
        private readonly IDocumentsService documentsService;

        public GuestsService(IDeletableEntityRepository<Guest> guestsRepository, IDeletableEntityRepository<GuestReservation> guestsReservationsRepository, IDocumentsService documentsService)
        {
            this.guestsRepository = guestsRepository;
            this.guestsReservationsRepository = guestsReservationsRepository;
            this.documentsService = documentsService;
        }

        public async Task Add(GuestAddBindingModel model, ApplicationUser user)
        {
            Guest guest = new Guest
            {
                ApplicationUser = user,
                Nationality = model.Nationality,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PersonalIdentificationNumber = model.PersonalIdentificationNumber,
                TelephoneNumber = model.TelephoneNumber,
                Gender = model.Gender,
                CityTax = 1, // calculate depending on the age
                BirthDate = model.BirthDate,
            };

            await this.guestsRepository.AddAsync(guest);
            await this.guestsRepository.SaveChangesAsync();

            await this.guestsReservationsRepository.AddAsync(new GuestReservation
            {
                ReservationId = model.ReservationId,
                GuestId = guest.Id,
            });

            await this.guestsReservationsRepository.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}