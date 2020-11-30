using Bychvata.Data.Models;
using Bychvata.Services.Data;
using Bychvata.Web.ViewModels.Models.BindingModels;
using Bychvata.Web.ViewModels.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bychvata.Web.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IReservationsService reservationsService;

        public ReservationsController(UserManager<ApplicationUser> userManager, IReservationsService reservationsService)
        {
            this.userManager = userManager;
            this.reservationsService = reservationsService;
        }

        // GET: ReservationsController
        public ActionResult Index()
        {
            return this.View();
        }

        // GET: ReservationsController/Details/5
        public ActionResult Details(int id)
        {
            return this.View();
        }

        // GET: ReservationsController/Create
        public ActionResult Create(AvailabilityBindingModel model)
        {
            this.ViewData["Arrival"] = model.Arrival.Date.ToString("yyyy-MM-dd");
            this.ViewData["Departure"] = model.Departure.Date.ToString("yyyy-MM-dd");
            return this.View();
        }

        // POST: ReservationsController/Create
        [HttpPost]
        public async Task<ActionResult> Create(ReservationCreateBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            string userIdClaimValue = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await this.reservationsService.CreateReservation(model, userIdClaimValue);

            if (result >= 0)
            {
                return this.RedirectToAction("Success");
            }
            else
            {
                return this.RedirectToAction("Failed");
            }
        }

        public IActionResult Success()
        {
            return this.View();
        }

        public IActionResult Failed()
        {
            return this.View();
        }

        public IActionResult MyReservations()
        {
            string userIdClaimValue = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            ICollection<ReservationViewModel> reservations = this.reservationsService.GetReservations(userIdClaimValue);

            return this.View(reservations);
        }

        // GET: ReservationsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationsController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ReservationCreateBindingModel model)
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

        // GET: ReservationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationsController/Delete/5
        [HttpPost]
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