namespace Bychvata.Web.Controllers
{
    using Bychvata.Data.Models;
    using Bychvata.Services.Data;
    using Bychvata.Web.ViewModels;
    using Bychvata.Web.ViewModels.Models.BindingModels;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeController : BaseController
    {
        private readonly IReservationsService reservationsService;
        private readonly IAdditionsService additionsService;

        public HomeController(IReservationsService reservationsService, IAdditionsService additionsService)
        {
            this.reservationsService = reservationsService;
            this.additionsService = additionsService;
        }

        public IActionResult Index(AvailabilityBindingModel model)
        {
            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public async Task<IActionResult> CheckAvailability(AvailabilityBindingModel model)
        {
            //Add wheather forecast api for the selected days if there are available
            if (!ModelState.IsValid)
            {
                model.ShouldShowAvailabilityDetails = false;

                return this.RedirectToAction("Index", model);
            }

            ICollection<Bungalow> bungalows = this.reservationsService.CheckAvailability(model);

            model.ShouldShowAvailabilityDetails = true;
            model.IsAvailable = bungalows.Count > 0;

            return this.RedirectToAction("Index", model);
        }

        public IActionResult Conditions()
        {
            return this.View();
        }

        public IActionResult Prices()
        {
            var model = this.additionsService.GetAll();

            return this.View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        public override RedirectToActionResult RedirectToAction(string actionName, object routeValues)
        {
            var redirectToActionResult = base.RedirectToAction(actionName, routeValues);

            var routeValuesType = routeValues.GetType();
            foreach (var routeValue in redirectToActionResult.RouteValues)
            {
                if (routeValue.Value is DateTime dateValue)
                {
                    var propertyInfo = routeValuesType.GetProperty(routeValue.Key);
                    if (propertyInfo != null)
                    {
                        var displayFormatAttribute = propertyInfo.GetCustomAttributes(typeof(DisplayFormatAttribute), true).FirstOrDefault() as DisplayFormatAttribute;
                        if (displayFormatAttribute != null)
                        {
                            redirectToActionResult.RouteValues[routeValue.Key] = string.Format(displayFormatAttribute.DataFormatString, dateValue);
                        }
                    }
                }
            }

            return redirectToActionResult;
        }
    }
}