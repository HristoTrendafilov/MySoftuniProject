namespace AllAboutGames.Web.Controllers
{
    using System.Threading.Tasks;

    using AllAboutGames.Common;
    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class GamesController : Controller
    {
        private readonly IGamesService gameService;
        private readonly IWebHostEnvironment environment;

        public GamesController(IGamesService gameService, IWebHostEnvironment environment)
        {
            this.gameService = gameService;
            this.environment = environment;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Add()
        {
            var viewModel = await this.gameService.GetAllInfoAsync();

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Add(AddGameInputModel model)
        {
            var viewModel = await this.gameService.GetAllInfoAsync();

            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var rootPath = this.environment.WebRootPath;
            await this.gameService.AddGameAsync(model, rootPath);
            return this.Redirect("/");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(string id)
        {
            var viewModel = await this.gameService.GetEditModel(id);

            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditGameInputModel model)
        {
            var rootPath = this.environment.WebRootPath;
            await this.gameService.EditGameAsync(id, model, rootPath);

            return this.Redirect($"/Games/Details?id={id}");
        }

        public async Task<IActionResult> Details(string id, string success = null)
        {
            // fix the exception
            this.ViewData["Success"] = success;
            try
            {
                await this.gameService.GetDetailsAsync(id);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction("Home", "Error404");
            }

            var viewModel = await this.gameService.GetDetailsAsync(id);
            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.gameService.DeleteGameAsync(id);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction("Home", "Error404");
            }

            await this.gameService.DeleteGameAsync(id);

            return this.Redirect("/");
        }
    }
}
