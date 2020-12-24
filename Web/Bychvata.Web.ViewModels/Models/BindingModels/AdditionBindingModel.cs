using Bychvata.Data.Models;
using Bychvata.Services.Mapping;

namespace Bychvata.Web.ViewModels.Models.BindingModels
{
    public class AdditionBindingModel : IMapFrom<Addition>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsIncluded { get; set; }
    }
}