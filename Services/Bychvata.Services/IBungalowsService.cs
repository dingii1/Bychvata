using Bychvata.Web.ViewModels.Models.ViewModels;
using System.Collections.Generic;

namespace Bychvata.Services
{
    public interface IBungalowsService
    {
        ICollection<BungalowViewModel> GetAll();
    }
}