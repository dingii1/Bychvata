using Bychvata.Data.Models;
using Bychvata.Web.ViewModels.Models.BindingModels;
using System.Threading.Tasks;

namespace Bychvata.Services
{
    public interface IGuestsService
    {
        Task Add(GuestAddBindingModel model, ApplicationUser user);

        void Delete(int id);
    }
}