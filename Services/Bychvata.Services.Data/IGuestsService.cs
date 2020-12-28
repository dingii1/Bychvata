using Bychvata.Data.Models;
using Bychvata.Web.ViewModels.Models.Guests;
using System.Threading.Tasks;

namespace Bychvata.Services.Data
{
    public interface IGuestsService
    {
        Task Add(GuestAddBindingModel model, ApplicationUser user);

        void Delete(int id);
    }
}