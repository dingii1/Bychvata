using Bychvata.Services.Data;
using Bychvata.Web.ViewModels.Models.Documents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bychvata.Web.Controllers
{
    [Authorize]
    public class DocumentsController : BaseController
    {
        private readonly IDocumentsService documentsService;

        public DocumentsController(IDocumentsService documentsService)
        {
            this.documentsService = documentsService;
        }

        public ActionResult Add(int id)
        {
            var model = new DocumentBindingModel();
            model.GuestId = id;

            return this.View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(DocumentBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await this.documentsService.AddAsync(model);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(model);
            }

            return this.Redirect("/Reservations/MyReservations");
        }

        public IActionResult Edit(int id)
        {
            DocumentEditBindingModel model = this.documentsService.Get(id);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DocumentEditBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.documentsService.UpdateAsync(model);

            return this.Redirect("/Reservations/MyReservations");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                this.documentsService.DeleteAsync(id);

                return this.Redirect("/Reservations/MyReservations");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                return this.Redirect("/Reservations/MyReservations");
            }
        }
    }
}