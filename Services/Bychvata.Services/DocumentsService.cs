using Bychvata.Data.Common.Repositories;
using Bychvata.Data.Models;
using Bychvata.Web.ViewModels.Models.BindingModels;
using System.Linq;
using System.Threading.Tasks;

namespace Bychvata.Services
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IRepository<Document> documentRepository;

        public DocumentsService(IRepository<Document> documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public async Task AddAsync(DocumentBindingModel model)
        {
            Document document = new Document
            {
                Type = model.Type,
                IssueDate = model.IssueDate,
                ExpireDate = model.ExpireDate,
                Number = model.Number,
                GuestId = model.GuestId,
            };

            await this.documentRepository.AddAsync(document);
        }

        public async Task<Document> GetByNumberAsync(string documentNumber)
        {
            return this.documentRepository.AllAsNoTracking()
                .Where(d => d.Number == documentNumber)
                .FirstOrDefault();
        }
    }
}