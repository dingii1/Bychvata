namespace Bychvata.Services.Data
{
    using Bychvata.Data.Common.Repositories;
    using Bychvata.Data.Models;
    using Bychvata.Services.Mapping;
    using Bychvata.Web.ViewModels.Administration.Bungalows;
    using Bychvata.Web.ViewModels.Models.Bungalows;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BungalowsService : IBungalowsService
    {
        private readonly IDeletableEntityRepository<Bungalow> bungalowsRepository;

        public BungalowsService(IDeletableEntityRepository<Bungalow> bungalowsRepository)
        {
            this.bungalowsRepository = bungalowsRepository;
        }

        public async Task CreateAsync(BungalowBindingModel model)
        {
            Bungalow bungalow = new Bungalow
            {
                Number = model.Number,
                Rooms = model.Rooms,
                Type = model.Type,
                IsAvailable = model.IsAvailable,
                Notes = model.Notes,
                Beds = model.Beds,
            };

            await this.bungalowsRepository.AddAsync(bungalow);
            await this.bungalowsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Bungalow bungalow = this.bungalowsRepository.All()
                .FirstOrDefault(b => b.Id == id);

            if (bungalow == null)
            {
                throw new ArgumentNullException("There is no bungalow with this id.");
            }

            this.bungalowsRepository.Delete(bungalow);
            await this.bungalowsRepository.SaveChangesAsync();
        }

        public ICollection<BungalowViewModel> GetAll()
        {
            return this.bungalowsRepository.All()
                .To<BungalowViewModel>()
                .ToList();
        }

        public T GetById<T>(int id)
        {
            return this.bungalowsRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
        }

        public async Task UpdateAsync(int id, BungalowBindingModel model)
        {
            Bungalow bungalow = this.bungalowsRepository.All()
                .FirstOrDefault(b => b.Id == id);

            if (bungalow == null)
            {
                throw new ArgumentNullException("There is no bungalow with this id.");
            }

            bungalow.Number = model.Number;
            bungalow.Rooms = model.Rooms;
            bungalow.Type = model.Type;
            bungalow.IsAvailable = model.IsAvailable;
            bungalow.Notes = model.Notes;
            bungalow.Beds = model.Beds;

            await this.bungalowsRepository.AddAsync(bungalow);
            await this.bungalowsRepository.SaveChangesAsync();
        }
    }
}