using Bychvata.Web.ViewModels.Models.ViewModels;
using System.Collections.Generic;

namespace Bychvata.Services.Data
{
    public interface IBungalowsService
    {
        ICollection<BungalowViewModel> GetAll();

        BungalowDetailViewModel GetById(int id);
    }
}