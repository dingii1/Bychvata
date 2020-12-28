namespace Bychvata.Web.ViewModels.Models.Bungalows
{
    using Bychvata.Data.Common.Enums;
    using Bychvata.Data.Models;
    using Bychvata.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class BungalowViewModel : IMapFrom<Bungalow>
    {
        public int Id { get; set; }

        [Display(Name = "Номер")]
        public int Number { get; set; }

        [Display(Name = "Брой стаи")]
        public int Rooms { get; set; }

        [Display(Name = "Легла")]
        public int Beds { get; set; }

        [Display(Name = "Тип")]
        public BungalowType Type { get; set; }

        [Display(Name = "Забележки")]
        public string Notes { get; set; }
    }
}