namespace AllAboutGames.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Ratings;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : Controller
    {
        private readonly IRatingsService ratingsService;

        public RatingsController(IRatingsService ratingsService)
        {
            this.ratingsService = ratingsService;
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<ActionResult<PostRatingViewModel>> Post(PostRatingInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.ratingsService.SetRatingAsync(input.GameId, userId, input.Value);

            var averageRating = this.ratingsService.GetAverageRating(input.GameId);

            return new PostRatingViewModel { AverageRating = averageRating };
        }
    }
}
