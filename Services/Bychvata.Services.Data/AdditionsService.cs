using Bychvata.Data.Common.Repositories;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using Bychvata.Web.ViewModels.Models.Additions;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<AdditionBindingModel> GetAdditionsBindingModel()
        {
            return this.additionsRepository.All()
                .Include(a => a.ReservationAdditions)
                .ThenInclude(ra => ra.Reservation)
                .To<AdditionBindingModel>()
                .ToList();
        }
    }
}