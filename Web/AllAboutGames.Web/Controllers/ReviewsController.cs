﻿namespace AllAboutGames.Web.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Add(AddReviewInputModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            model.UserId = userId;
            await this.reviewService.AddAsync(model);

            return this.Redirect($"/Games/Details?id={model.GameId}&success=true");
        }

        public async Task<IActionResult> Details(string id, int pageNumber = 1)
        {
            this.ViewData["ActionName"] = this.ControllerContext.ActionDescriptor.ActionName;
            var viewModel = new AllUserReviewsListViewModel
            {
                ItemsPerPage = ReviewsPerPage,
                PageNumber = pageNumber,
                Count = await this.reviewService.GetCurrentGameReviewsCount(id),
                Reviews = await this.reviewService.GetReviewDetailsAsync(id, pageNumber, ReviewsPerPage),
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            await this.reviewService.DeleteReviewsAsync(id);

            return this.RedirectToAction("Details");
        }
    }
}
