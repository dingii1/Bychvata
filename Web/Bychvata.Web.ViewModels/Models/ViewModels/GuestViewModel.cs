using AutoMapper;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;

namespace Bychvata.Web.ViewModels.Models.ViewModels
{
    public class GuestViewModel : IMapFrom<Guest>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TelephoneNumber { get; set; }

        public int? DocumentId { get; set; }

        public bool HasDocument { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Guest, GuestViewModel>()
                .ForMember(gvm => gvm.HasDocument, opt =>
                    opt.MapFrom(g => g.DocumentId != null));
        }
    }
}