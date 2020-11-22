namespace AllAboutGames.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.AspNetCore.Mvc;

    public class PlatformsController : Controller
    {
        private readonly IPlatformsService platformService;

        public PlatformsController(IPlatformsService platformService)
        {
            this.platformService = platformService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPlatformInputModel model)
        {
            if (this.platformService.CheckIfPlatformExists(model.Name))
            {
                return this.Redirect("/Platforms/Add");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.platformService.AddPlatformAsync(model);
            return this.RedirectToAction("Add");
        }

        public async Task<IActionResult> Playstation()
        {
            var consoleName = this.ControllerContext.ActionDescriptor.ActionName;
            this.ViewData["ConsoleName"] = consoleName;
            var viewModel = this.platformService.GetAllGamesByPlatform(consoleName);

            return this.View("All", viewModel);
        }

        public async Task<IActionResult> Xbox()
        {
            var consoleName = this.ControllerContext.ActionDescriptor.ActionName;
            this.ViewData["ConsoleName"] = consoleName;
            var viewModel = this.platformService.GetAllGamesByPlatform(consoleName);

            return this.View("All", viewModel);
        }

        public async Task<IActionResult> PC()
        {
            var consoleName = this.ControllerContext.ActionDescriptor.ActionName;
            this.ViewData["ConsoleName"] = consoleName;
            var viewModel = this.platformService.GetAllGamesByPlatform(consoleName);

            return this.View("All", viewModel);
        }

        public async Task<IActionResult> Nintendo()
        {
            var consoleName = this.ControllerContext.ActionDescriptor.ActionName;
            this.ViewData["ConsoleName"] = consoleName;
            var viewModel = this.platformService.GetAllGamesByPlatform(consoleName);

            return this.View("All", viewModel);
        }

        public async Task<IActionResult> Android()
        {
            var consoleName = this.ControllerContext.ActionDescriptor.ActionName;
            this.ViewData["ConsoleName"] = consoleName;
            var viewModel = this.platformService.GetAllGamesByPlatform(consoleName);

            return this.View("All", viewModel);
        }

        public async Task<IActionResult> iOS()
        {
            var consoleName = this.ControllerContext.ActionDescriptor.ActionName;
            this.ViewData["ConsoleName"] = consoleName;
            var viewModel = this.platformService.GetAllGamesByPlatform(consoleName);

            return this.View("All", viewModel);
        }
    }
}
