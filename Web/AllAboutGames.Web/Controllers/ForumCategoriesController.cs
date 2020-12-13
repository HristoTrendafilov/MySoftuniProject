﻿using AllAboutGames.Common;
using AllAboutGames.Services.Data;
using AllAboutGames.Web.ViewModels.ForumCategories;
using AllAboutGames.Web.ViewModels.InputModels;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Add(string id)
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> Add(AddForumCategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.forumService.AddCategoryAsync(model);
            return this.RedirectToAction("Index", "Forum");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            await this.forumService.DeleteCategoryAsync(id);
            return this.RedirectToAction("Index", "Forum");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(string id)
        {
            var viewModel = await this.forumService.GetByIdAsync<AddForumCategoryInputModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(string id, AddForumCategoryInputModel model)
        {
            await this.forumService.EditCategoryAsync(id, model);
            return this.RedirectToAction("Index", "Forum");
        }
    }
}
