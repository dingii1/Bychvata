namespace Bychvata.Web.Controllers
{
    using Bychvata.Data.Models;
    using Bychvata.Services.Data;
    using Bychvata.Web.ViewModels;
    using Bychvata.Web.ViewModels.Models.BindingModels;
    using Bychvata.Web.ViewModels.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : BaseController
    {
        private readonly IReservationsService reservationsService;

        public HomeController(IReservationsService reservationsService)
        {
            this.reservationsService = reservationsService;
        }

        public IActionResult Index()
        {
            var model = new AvailabilityBindingModel();

            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public async Task<IActionResult> CheckAvailability(string arrival, string departure)
        {
            var model = new AvailabilityBindingModel
            {
                Arrival = Convert.ToDateTime(arrival),
                Departure = Convert.ToDateTime(departure),
            };

            //Add wheather forecast api for the selected days if there are available
            //TODO: Repair validations messagges
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Index", model);
            }

            ICollection<Bungalow> bungalows = this.reservationsService.CheckAvailability(model);

            var viewModel = new AvailabilityViewModel()
            {
                Arrival = model.Arrival,
                Departure = model.Departure,
                IsAvailable = bungalows.Count > 0 ? true : false,
            };

            return this.PartialView("_CheckAvailabilityPartial", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}