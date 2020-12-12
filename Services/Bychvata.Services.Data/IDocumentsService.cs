using Bychvata.Data.Models;
using Bychvata.Web.ViewModels.Models.BindingModels;
using System.Threading.Tasks;

namespace Bychvata.Services.Data
{
    public interface IDocumentsService
    {
        Task AddAsync(DocumentBindingModel model);

        Task<Document> GetByNumberAsync(string documentNumber);
    }
}