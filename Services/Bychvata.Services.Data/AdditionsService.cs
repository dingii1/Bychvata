using Bychvata.Data.Common.Repositories;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using Bychvata.Web.ViewModels.Models.Additions;
using System.Collections.Generic;
using System.Linq;

namespace Bychvata.Services.Data
{
    public class AdditionsService : IAdditionsService
    {
        private readonly IDeletableEntityRepository<Addition> additionsRepository;

        public AdditionsService(IDeletableEntityRepository<Addition> additionsRepository)
        {
            this.additionsRepository = additionsRepository;
        }

        public IEnumerable<AdditionViewModel> GetAll()
        {
            return this.additionsRepository.All()
                .To<AdditionViewModel>()
                .ToList();
        }

        public IList<AdditionBindingModel> GetAdditionBindingModels()
        {
            return this.additionsRepository.All()
                .To<AdditionBindingModel>()
                .ToList();
        }
    }
}