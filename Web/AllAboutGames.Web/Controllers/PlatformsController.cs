namespace AllAboutGames.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Platforms;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class PlatformsController : Controller
    {
        private const int ItemsPerPage = 8;
        private readonly IPlatformsService platformService;
        private readonly IWebHostEnvironment environment;

        public PlatformsController(IPlatformsService platformService, IWebHostEnvironment environment)
        {
            this.platformService = platformService;
            this.environment = environment;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Add(AddPlatformInputModel model)
        {
            var rootPath = this.environment.WebRootPath;

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.platformService.AddPlatformAsync(model, rootPath);
            return this.RedirectToAction("Add");
        }

        public async Task<IActionResult> Playstation(int id = 1)
        {
            var platformName = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = await this.GetDataAsync(id, platformName, ItemsPerPage);

            return this.View("All", viewModel);
        }

        public async Task<IActionResult> Xbox(int id = 1)
        {
            var platformName = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = await this.GetDataAsync(id, platformName, ItemsPerPage);

            return this.View("All", viewModel);
        }

        public async Task<IActionResult> PC(int id = 1)
        {
            var platformName = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = await this.GetDataAsync(id, platformName, ItemsPerPage);

            return this.View("All", viewModel);
        }

        public async Task<IActionResult> Nintendo(int id = 1)
        {
            var platformName = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = await this.GetDataAsync(id, platformName, ItemsPerPage);

            return this.View("All", viewModel);
        }

        public async Task<IActionResult> Android(int id = 1)
        {
            var platformName = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = await this.GetDataAsync(id, platformName, ItemsPerPage);

            return this.View("All", viewModel);
        }

        public async Task<IActionResult> iOS(int id = 1)
        {
            var platformName = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = await this.GetDataAsync(id, platformName, ItemsPerPage);

            return this.View("All", viewModel);
        }

        private async Task<AllGamesListViewModel> GetDataAsync(int id, string platformName, int itemsPerPage)
        {
            this.ViewData["ActionName"] = platformName;
            return new AllGamesListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                GamesCount = this.platformService.GetGamesCount(platformName),
                Games = await this.platformService.GetAllGamesByPlatformAsync(platformName, id, itemsPerPage),
            };
        }
    }
}
