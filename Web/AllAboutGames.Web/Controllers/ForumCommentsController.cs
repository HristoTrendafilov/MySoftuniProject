using AllAboutGames.Services.Data;
using AllAboutGames.Web.ViewModels.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AllAboutGames.Web.Controllers
{
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
            await this.forumService.DeleteCommentAsync(id);

            return this.RedirectToAction("Details", "ForumPosts", new { id = postId });
        }
    }
}
