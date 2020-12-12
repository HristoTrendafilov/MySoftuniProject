using AllAboutGames.Services.Data;
using AllAboutGames.Web.ViewModels.ForumCategories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutGames.Web.Controllers
{
    public class ForumCategoriesController : Controller
    {
        private readonly IForumService forumService;

        public ForumCategoriesController(IForumService forumService)
        {
            this.forumService = forumService;
        }

        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.forumService.GetByIdAsync<CategoryViewModel>(id, "Desc");

            return this.View(viewModel);
        }
    }
}
