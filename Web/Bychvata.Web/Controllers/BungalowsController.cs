using Bychvata.Services.Data;
using Bychvata.Web.ViewModels.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bychvata.Web.Controllers
{
    [Authorize]
    public class BungalowsController : BaseController
    {
        private readonly IBungalowsService bungalowsService;

        public BungalowsController(IBungalowsService bungalowsService)
        {
            this.bungalowsService = bungalowsService;
        }

        // GET: BungalowsController
        public ActionResult Index()
        {
            // bungalowService to get all bungalows and pass to the view as model
            ICollection<BungalowViewModel> bungalows = this.bungalowsService.GetAll();

            return this.View(bungalows);
        }

        // GET: BungalowsController/Details/5
        public ActionResult Details(int id)
        {
            return this.View();
        }
    }
}