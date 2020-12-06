using Bychvata.Data.Models;
using Bychvata.Services;
using Bychvata.Web.ViewModels.Models.BindingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bychvata.Web.Controllers
{
    public class GuestsController : Controller
    {
        private readonly IGuestsService guestsService;
        private readonly UserManager<ApplicationUser> userManager;

        public GuestsController(IGuestsService guestsService, UserManager<ApplicationUser> userManager)
        {
            this.guestsService = guestsService;
            this.userManager = userManager;
        }

        // GET: GuestsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GuestsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GuestsController/Add
        public ActionResult Add(int id)
        {
            var model = new GuestAddBindingModel();
            model.ReservationId = id;

            return this.View(model);
        }

        // POST: GuestsController/Add
        [HttpPost]
        public async Task<ActionResult> Add(GuestAddBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.guestsService.Add(model, user);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(model);
            }

            return this.RedirectToAction("Details", "Reservations", model.ReservationId);
        }

        // GET: GuestsController/Edit/5
        public ActionResult Edit(int id)
        {
            return this.View();
        }

        // POST: GuestsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GuestsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GuestsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}