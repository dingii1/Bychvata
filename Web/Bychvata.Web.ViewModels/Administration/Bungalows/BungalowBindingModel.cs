namespace Bychvata.Web.ViewModels.Administration.Bungalows
{
    using Bychvata.Data.Common.Enums;
    using Bychvata.Data.Models;
    using Bychvata.Services.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class BungalowBindingModel : IMapFrom<Bungalow>
    {
        [Display(Name = "Номер")]
        public int Number { get; set; }

        [Display(Name = "Брой стаи")]
        public int Rooms { get; set; }

        [Display(Name = "Легла")]
        public int Beds { get; set; }

        [Display(Name = "Тип")]
        public BungalowType Type { get; set; }

        [Display(Name = "На разположение")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Забележки")]
        public string Notes { get; set; }
    }
}