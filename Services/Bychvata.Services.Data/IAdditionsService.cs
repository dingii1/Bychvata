using Bychvata.Web.ViewModels.Models.Additions;
using System.Collections.Generic;

namespace Bychvata.Services.Data
{
    public interface IAdditionsService
    {
        IEnumerable<AdditionViewModel> GetAll();

        IList<AdditionBindingModel> GetAdditionBindingModels();
    }
}