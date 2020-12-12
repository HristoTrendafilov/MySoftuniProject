namespace AllAboutGames.Web.Controllers
{
    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.Forum;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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
                Categories = await this.forumService.GetAllAsync<IndexCategoryViewMode>(),
            };

            return this.View(viewModel);
        }
    }
}
