namespace AllAboutGames.Web.Controllers
{
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.AspNetCore.Mvc;

    public class GamesController : Controller
    {
        private readonly IGamesService gameService;

        public GamesController(IGamesService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = this.gameService.GetAllInfo();

            return this.View(viewModel);
        }

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
    }
}
