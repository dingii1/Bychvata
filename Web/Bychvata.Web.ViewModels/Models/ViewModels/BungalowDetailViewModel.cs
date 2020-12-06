using Bychvata.Data.Models;
using System.Collections.Generic;

namespace Bychvata.Web.ViewModels.Models.ViewModels
{
    public class BungalowDetailViewModel : BungalowViewModel
    {
        public virtual IEnumerable<DateAvailable> DatesAvailable { get; set; } = new HashSet<DateAvailable>();
    }
}