namespace Bychvata.Web.Controllers
{
    using Bychvata.Data.Models;
    using Bychvata.Services.Data;
    using Bychvata.Web.ViewModels.Models.Guests;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Authorize]
    public class GuestsController : BaseController
    {
        private readonly IGuestsService guestsService;
        private readonly UserManager<ApplicationUser> userManager;

        public GuestsController(IGuestsService guestsService, UserManager<ApplicationUser> userManager)
        {
            this.guestsService = guestsService;
            this.userManager = userManager;
        }

        public ActionResult Add(int id)
        {
            var model = new GuestAddBindingModel();
            model.ReservationId = id;

            return this.View(model);
        }

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
    }
}