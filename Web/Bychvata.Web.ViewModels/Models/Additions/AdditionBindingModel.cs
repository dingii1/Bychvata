namespace Bychvata.Web.ViewModels.Models.Additions
{
    using AutoMapper;
    using Bychvata.Common.Extensions;
    using Bychvata.Data.Models;
    using Bychvata.Services.Mapping;
    using System.Linq;
    using System.Runtime.Serialization;

    public class AdditionBindingModel : IMapFrom<Addition>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsIncluded { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Addition, AdditionBindingModel>()
                .ForMember(x => x.Name, opt =>
                    opt.MapFrom(a => a.Name.GetName<EnumMemberAttribute>()))
                .ForMember(x => x.Price, opt =>
                    opt.MapFrom(a => a.Value));
        }
    }
}