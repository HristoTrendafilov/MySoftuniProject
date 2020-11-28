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
        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = this.gameService.GetAllInfo();

            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Add(AddGameInputModel model)
        {
            var viewModel = this.gameService.GetAllInfo();

            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.gameService.AddGameAsync(model);
            return this.Redirect("/");
        }

        public IActionResult Details(string id, string success = null)
        {
            this.ViewData["Success"] = success;
            var viewModel = this.gameService.GetDetails(id);

            return this.View(viewModel);
        }
    }
}
