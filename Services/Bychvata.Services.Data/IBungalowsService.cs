using Bychvata.Web.ViewModels.Administration.Bungalows;
using Bychvata.Web.ViewModels.Models.Bungalows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bychvata.Services.Data
{
    public interface IBungalowsService
    {
        ICollection<BungalowViewModel> GetAll();

        T GetById<T>(int id);

        Task CreateAsync(BungalowBindingModel model);

        Task UpdateAsync(int id, BungalowBindingModel model);

        Task DeleteAsync(int id);
    }
}