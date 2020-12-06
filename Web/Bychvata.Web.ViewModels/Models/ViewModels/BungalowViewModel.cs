using Bychvata.Data.Common.Enums;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;

namespace Bychvata.Web.ViewModels.Models.ViewModels
{
    public class BungalowViewModel : IMapFrom<Bungalow>
    {
        public int Number { get; set; }

        public int Rooms { get; set; }

        public int Beds { get; set; }

        public BungalowType Type { get; set; }

        public string Notes { get; set; }
    }
}