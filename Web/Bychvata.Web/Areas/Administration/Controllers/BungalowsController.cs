namespace Bychvata.Web.Areas.Administration.Controllers
{
    using Bychvata.Services.Data;
    using Bychvata.Web.ViewModels.Administration.Bungalows;
    using Bychvata.Web.ViewModels.Models.Bungalows;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Area("Administration")]
    public class BungalowsController : AdministrationController
    {
        private readonly IBungalowsService bungalowsService;

        public BungalowsController(IBungalowsService bungalowsService)
        {
            this.bungalowsService = bungalowsService;
        }

        public IActionResult Index()
        {
            IEnumerable<BungalowViewModel> model = this.bungalowsService.GetAll();

            return this.View(model);
        }

        public IActionResult Details(int id)
        {
            BungalowDetailViewModel model = this.bungalowsService.GetById<BungalowDetailViewModel>(id);
            if (model == null)
            {
                return this.NotFound();
            }

            return this.View(model);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BungalowBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.bungalowsService.CreateAsync(model);
            return this.RedirectToAction(nameof(this.Index));
        }

        public IActionResult Edit(int id)
        {
            BungalowBindingModel model = this.bungalowsService.GetById<BungalowBindingModel>(id);

            this.ViewBag.Id = id;

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BungalowBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.bungalowsService.UpdateAsync(id, model);

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await this.bungalowsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}