using Bychvata.Data.Common.Repositories;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using Bychvata.Web.ViewModels.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Bychvata.Services.Data
{
    public class BungalowsService : IBungalowsService
    {
        private readonly IDeletableEntityRepository<Bungalow> bungalowsRepository;

        public BungalowsService(IDeletableEntityRepository<Bungalow> bungalowsRepository)
        {
            this.bungalowsRepository = bungalowsRepository;
        }

        public ICollection<BungalowViewModel> GetAll()
        {
            return this.bungalowsRepository.All()
                .To<BungalowViewModel>()
                .ToList();
        }
    }
}