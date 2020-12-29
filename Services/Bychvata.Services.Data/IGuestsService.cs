namespace Bychvata.Services.Data
{
    using Bychvata.Data.Models;
    using Bychvata.Web.ViewModels.Models.Guests;
    using System.Threading.Tasks;

    public interface IGuestsService
    {
        Task Add(GuestAddBindingModel model, ApplicationUser user);
    }
}