namespace Bychvata.Web.ViewModels.Models.Guests
{
    using Bychvata.Data.Models;
    using Bychvata.Services.Mapping;

    public class GuestDetailViewModel : GuestViewModel, IMapFrom<Guest>
    {
    }
}