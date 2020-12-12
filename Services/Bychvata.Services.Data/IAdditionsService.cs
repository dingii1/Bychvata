using Bychvata.Web.ViewModels.Models.ViewModels;
using System.Collections.Generic;

namespace Bychvata.Services.Data
{
    public interface IAdditionsService
    {
        ICollection<AdditionViewModel> GetAll();
    }
}