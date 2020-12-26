using AutoMapper;
using Bychvata.Data.Common.Enums;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using System.Linq;

namespace Bychvata.Web.ViewModels.Models.BindingModels
{
    public class AdditionBindingModel : IMapFrom<Addition>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public AdditionType Name { get; set; }

        public bool IsIncluded { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Addition, AdditionBindingModel>()
                .ForMember(x => x.IsIncluded, opt =>
                    opt.MapFrom(a => a.ReservationAdditions.Any(reservationAddition => reservationAddition.Id == a.Id)));
        }
    }
}