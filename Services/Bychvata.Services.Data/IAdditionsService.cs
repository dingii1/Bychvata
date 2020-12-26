using Bychvata.Web.ViewModels.Models.BindingModels;
using Bychvata.Web.ViewModels.Models.ViewModels;
using System.Collections.Generic;

namespace Bychvata.Services.Data
{
    public interface IAdditionsService
    {
        IEnumerable<AdditionViewModel> GetAll();

        IEnumerable<AdditionBindingModel> GetAdditionsBindingModel();
    }
}