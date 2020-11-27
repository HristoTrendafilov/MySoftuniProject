﻿namespace AllAboutGames.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Platforms;
    using Microsoft.AspNetCore.Mvc;

    public class PlatformsController : Controller
    {
        private const int ItemsPerPage = 8;
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

        public IActionResult Playstation(int id = 1)
        {
            var platformName = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = this.GetData(id, platformName, ItemsPerPage);

            return this.View("All", viewModel);
        }

        public IActionResult Xbox(int id = 1)
        {
            var platformName = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = this.GetData(id, platformName, ItemsPerPage);

            return this.View("All", viewModel);
        }

        public IActionResult PC(int id)
        {
            var platformName = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = this.GetData(id, platformName, ItemsPerPage);

            return this.View("All", viewModel);
        }

        public IActionResult Nintendo(int id = 1)
        {
            var platformName = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = this.GetData(id, platformName, ItemsPerPage);

            return this.View("All", viewModel);
        }

        public IActionResult Android(int id = 1)
        {
            var platformName = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = this.GetData(id, platformName, ItemsPerPage);

            return this.View("All", viewModel);
        }

        public IActionResult iOS(int id = 1)
        {
            var platformName = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = this.GetData(id, platformName, ItemsPerPage);

            return this.View("All", viewModel);
        }

        private AllGamesListViewModel GetData(int id, string platformName, int itemsPerPage)
        {
            this.ViewData["PlatformName"] = platformName;
            return new AllGamesListViewModel
            {
                ItemsPerPage = itemsPerPage,
                PageNumber = id,
                GamesCount = this.platformService.GetGamesCount(platformName),
                Games = this.platformService.GetAllGamesByPlatform(platformName, id, itemsPerPage),
            };
        }
    }
}
