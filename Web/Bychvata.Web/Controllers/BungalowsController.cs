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

        public ActionResult Index()
        {
            ICollection<BungalowViewModel> bungalows = this.bungalowsService.GetAll();

            return this.View(bungalows);
        }

        public ActionResult Details(int id)
        {
            BungalowDetailViewModel model = this.bungalowsService.GetById(id);

            return this.View(model);
        }
    }
}