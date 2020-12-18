namespace AllAboutGames.Web.Controllers
{
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.Forum;
    using Microsoft.AspNetCore.Mvc;

    public class ForumController : Controller
    {
        private readonly IForumService forumService;

        public ForumController(IForumService forumService)
        {
            this.forumService = forumService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel
            {
                Categories = await this.forumService.GetAllCategoriesAsync<IndexCategoryViewMode>(),
                TotalPostsCount = this.forumService.GetTotalPostsCount(),
            };

            return this.View(viewModel);
        }
    }
}
