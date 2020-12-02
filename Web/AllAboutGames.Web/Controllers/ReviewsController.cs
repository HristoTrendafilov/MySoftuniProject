namespace AllAboutGames.Web.Controllers
{
    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class ReviewsController : Controller
    {
        private readonly IReviewsService reviewService;

        public ReviewsController(IReviewsService reviewService)
        {
            this.reviewService = reviewService;
        }

        public async Task<IActionResult> All()
        {
            var viewModel = await this.reviewService.GetAllAsync();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddReviewInputModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            model.UserId = userId;
            await this.reviewService.AddAsync(model);

            return this.Redirect($"/Games/Details?id={model.GameId}&success=true");
        }

        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.reviewService.GetReviewDetailsAsync(id);

            return this.View(viewModel);
        }
    }
}
