namespace AllAboutGames.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.ForumPosts;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ForumPostsController : Controller
    {
        private readonly IForumService forumService;

        public ForumPostsController(IForumService forumService)
        {
            this.forumService = forumService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await this.forumService.GetAllAsync<CategoryDropDownViewModel>();
            var viewModel = new AddForumPostInputModel()
            {
                ForumCategories = categories,
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddForumPostInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var forumCategoryId = await this.forumService.AddForumPostAsync(model, userId);

            return this.RedirectToAction("Details", "ForumCategories", new { id = forumCategoryId });
        }

        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.forumService.GetPostByIdAsync<PostViewModel>(id);
            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.forumService.DeletePostAsync(id);
            return this.RedirectToAction("Index", "Forum");

        }

        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var categories = await this.forumService.GetAllAsync<CategoryDropDownViewModel>();
            var viewModel = await this.forumService.GetCurrentPost(id);
            viewModel.ForumCategories = categories;
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, AddForumPostInputModel model)
        {
            await this.forumService.EditPostAsync(id, model);
            return this.RedirectToAction("Details", "ForumCategories", new { id = model.ForumCategoryId });
        }
    }
}
