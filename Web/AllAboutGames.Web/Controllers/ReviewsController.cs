namespace AllAboutGames.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : Controller
    {
        private const int ItemsPerPage = 8;
        private readonly IReviewsService reviewService;

        public ReviewsController(IReviewsService reviewService)
        {
            this.reviewService = reviewService;
        }

        public async Task<IActionResult> All(int id = 1)
        {
            this.ViewData["ActionName"] = this.ControllerContext.ActionDescriptor.ActionName;

            var viewModel = new AllReviewsListViewModel
            {
                GamesCount = this.reviewService.GetReviewsCount(),
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Reviews = await this.reviewService.GetAllAsync(id, ItemsPerPage),
            };

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
