namespace Bychvata.Web.Areas.Administration.Controllers
{
    using Bychvata.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        //private readonly ISettingsService settingsService;

        public DashboardController()
        {
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = 5, };
            return this.View(viewModel);
        }
    }
}