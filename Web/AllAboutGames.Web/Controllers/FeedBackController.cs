using AllAboutGames.Common;
using AllAboutGames.Data.Common.Repositories;
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
    public class FeedBackController : Controller
    {
        private readonly IFeedBackService feedBackService;

        public FeedBackController(IFeedBackService feedBackService)
        {
            this.feedBackService = feedBackService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Contacts(string success = null)
        {
            this.ViewData["Success"] = success;
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Contacts(AddFeedBackInputModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.feedBackService.AddAsync(model, userId);

            return this.RedirectToAction("Contacts", new { success = "true" });
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult All()
        {
            var viewModel = this.feedBackService.GetAll();
            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            await this.feedBackService.DeleteFeedBackAsync(id);

            return this.RedirectToAction("All");
        }
    }
}
