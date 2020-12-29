namespace Bychvata.Services.Data
{
    using Bychvata.Web.ViewModels.Models.Additions;
    using System.Collections.Generic;

    public interface IAdditionsService
    {
        IEnumerable<AdditionViewModel> GetAll();

        IList<AdditionBindingModel> GetAdditionBindingModels();
    }
}