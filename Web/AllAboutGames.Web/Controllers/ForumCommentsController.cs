namespace AllAboutGames.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ForumCommentsController : Controller
    {
        private readonly IForumService forumService;

        public ForumCommentsController(IForumService forumService)
        {
            this.forumService = forumService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddForumPostCommentInputModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.forumService.AddCommentAsync(model.Text, model.PostId, userId);

            return this.RedirectToAction("Details", "ForumPosts", new { id = model.PostId });
        }

        [Authorize]
        public async Task<IActionResult> Delete(string id, string postId)
        {
            try
            {
                await this.forumService.DeleteCommentAsync(id);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction("Home", "Error404");
            }

            return this.RedirectToAction("Details", "ForumPosts", new { id = postId });
        }
    }
}
