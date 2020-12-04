namespace AllAboutGames.Web.Controllers
{
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class GamesController : Controller
    {
        private readonly IGamesService gameService;

        public GamesController(IGamesService gameService)
        {
            this.gameService = gameService;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Add()
        {
            var viewModel = await this.gameService.GetAllInfoAsync();

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Add(AddGameInputModel model)
        {
            var viewModel = await this.gameService.GetAllInfoAsync();

            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.gameService.AddGameAsync(model);
            return this.Redirect("/");
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(string id)
        {
            var viewModel = await this.gameService.GetEditModel(id);

            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditGameInputModel model)
        {
            await this.gameService.EditGameAsync(id, model);

            return this.Redirect($"/Games/Details?id={id}");
        }

        public async Task<IActionResult> Details(string id, string success = null)
        {
            this.ViewData["Success"] = success;
            var viewModel = await this.gameService.GetDetailsAsync(id);

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.gameService.DeleteGameAsync(id);

            return this.Redirect("/");
        }
    }
}
