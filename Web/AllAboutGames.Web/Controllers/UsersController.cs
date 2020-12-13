namespace AllAboutGames.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AllAboutGames.Common;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IWebHostEnvironment environment;

        public UsersController(
            IUsersService usersService,
            IWebHostEnvironment environment)
        {
            this.usersService = usersService;
            this.environment = environment;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult AddToRole()
        {
            var viewModel = this.usersService.GetDataForRoleAdding();
            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleInputModel model)
        {
            var viewModel = this.usersService.GetDataForRoleAdding();

            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.usersService.AddUserToRole(model);
            return this.Redirect("/");
        }

        public async Task<IActionResult> Profile(string id)
        {
            var viewModel = await this.usersService.GetUserDetailsAsync(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(AddProfilePictureToUserInputModel model)
        {
            var rootPath = this.environment.WebRootPath;

            await this.usersService.ChangeProfilePictureAsync(model, rootPath);
            return this.RedirectToAction("Profile");
        }
    }
}
