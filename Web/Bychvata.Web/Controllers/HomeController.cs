namespace Bychvata.Web.Controllers
{
    using Bychvata.Web.ViewModels;
    using Bychvata.Web.ViewModels.Models.BindingModels;
    using Bychvata.Web.ViewModels.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult CheckAvailability(AvailabilityBindingModel model)
        {
            //Use AvailabilityService returns true or false
            //Add wheather forecast api for the selected days if there are available and OpenStreetMap with location
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Index");
            }

            var viewModel = new AvailabilityViewModel()
            {
                From = model.From,
                To = model.To,
                IsAvailable = false,
            };

            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}