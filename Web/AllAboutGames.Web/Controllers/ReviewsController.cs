namespace AllAboutGames.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AllAboutGames.Common;
    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : Controller
    {
        private const int ItemsPerPage = 8;
        private const int ReviewsPerPage = 5;
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
                Count = this.reviewService.GetReviewsCount(),
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                Reviews = await this.reviewService.GetAllAsync(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddReviewInputModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            model.UserId = userId;
            await this.reviewService.AddAsync(model);

            return this.RedirectToAction("Details", "Games", new { id = model.GameId, success = "true" });
        }

        public async Task<IActionResult> Details(string id, int pageNumber = 1)
        {
            this.ViewData["ActionName"] = this.ControllerContext.ActionDescriptor.ActionName;

            try
            {
                await this.reviewService.GetReviewDetailsAsync(id, pageNumber, ReviewsPerPage);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction("Index", "Error404");
            }

            var viewModel = new AllUserReviewsListViewModel
            {
                ItemsPerPage = ReviewsPerPage,
                PageNumber = pageNumber,
                Count = await this.reviewService.GetCurrentGameReviewsCount(id),
                Reviews = await this.reviewService.GetReviewDetailsAsync(id, pageNumber, ReviewsPerPage),
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ReviwerRoleName)]
        public async Task<IActionResult> Delete(DeleteReviewInputModel model)
        {
            try
            {
                await this.reviewService.DeleteReviewsAsync(model.Id);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction("Home", "Error404");
            }

            return this.RedirectToAction("Details", new { id = model.GameId, pageNumber = 1 });
        }
    }
}
