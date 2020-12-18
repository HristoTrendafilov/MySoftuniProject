namespace AllAboutGames.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.ForumLikes;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class ForumLikesController : Controller
    {
        private readonly IForumService forumService;

        public ForumLikesController(IForumService forumService)
        {
            this.forumService = forumService;
        }

        [Authorize]
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<ActionResult<LikesResponseViewModel>> Like(AddForumLikeInputModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.forumService.LikeAsync(model.ForumPostId, userId);
            var likesCount = this.forumService.GetLikes(model.ForumPostId);
            return new LikesResponseViewModel { LikesCount = likesCount };
        }
    }
}
