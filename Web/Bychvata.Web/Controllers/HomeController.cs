namespace Bychvata.Web.Controllers
{
    using Bychvata.Services.Data;
    using Bychvata.Web.ViewModels;
    using Bychvata.Web.ViewModels.Models.BindingModels;
    using Bychvata.Web.ViewModels.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;
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
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckAvailability(AvailabilityBindingModel model)
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
                IsAvailable = false //await this.reservationsService.CheckAvailability(model),
            };

            viewModel.IsAvailable = true;
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