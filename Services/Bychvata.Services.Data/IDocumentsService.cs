namespace Bychvata.Services.Data
{
    using Bychvata.Web.ViewModels.Models.Documents;
    using System.Threading.Tasks;

    public interface IDocumentsService
    {
        Task AddAsync(DocumentBindingModel model);

        Task DeleteAsync(int id);

        DocumentEditBindingModel Get(int guestId);

        Task UpdateAsync(DocumentEditBindingModel model);
    }
}