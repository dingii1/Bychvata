using Bychvata.Data.Common.Repositories;
using Bychvata.Data.Models;
using Bychvata.Services.Mapping;
using Bychvata.Web.ViewModels.Models.Documents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bychvata.Services.Data
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IRepository<Document> documentRepository;
        private readonly IRepository<Guest> guestRepository;

        public DocumentsService(IRepository<Document> documentRepository, IRepository<Guest> guestRepository)
        {
            this.documentRepository = documentRepository;
            this.guestRepository = guestRepository;
        }

        public async Task AddAsync(DocumentBindingModel model)
        {
            Guest guest = this.guestRepository.All()
                .FirstOrDefault(g => g.Id == model.GuestId);

            if (guest.DocumentId == null)
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

                await this.documentRepository.SaveChangesAsync();

                guest.Document = document;
                await this.guestRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            Document document = this.documentRepository.All()
                .FirstOrDefault(d => d.Id == id);

            if (document == null)
            {
                throw new ArgumentNullException("There is no document with this id.");
            }
            else
            {
                this.documentRepository.Delete(document);
                await this.documentRepository.SaveChangesAsync();
            }
        }

        public DocumentEditBindingModel Get(int id)
        {
            return this.documentRepository.AllAsNoTracking()
                .Include(d => d.Guest)
                .Where(d => d.Id == id)
                .To<DocumentEditBindingModel>()
                .FirstOrDefault();
        }

        public async Task UpdateAsync(DocumentEditBindingModel model)
        {
            Document document = this.documentRepository.All()
                .Where(d => d.Id == model.Id)
                .FirstOrDefault();

            if (document == null)
            {
                throw new ArgumentNullException("There is no document with this id.");
            }
            else
            {
                document.Type = model.Type;
                document.Number = model.Number;
                document.IssueDate = model.IssueDate;
                document.ExpireDate = model.ExpireDate;

                await this.guestRepository.SaveChangesAsync();
            }
        }
    }
}