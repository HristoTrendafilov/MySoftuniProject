namespace AllAboutGames.Web.Controllers
{
    using System.Threading.Tasks;

    using AllAboutGames.Common;
    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
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

        [Authorize]
        public async Task<IActionResult> Profile(string id)
        {
            try
            {
                await this.usersService.GetUserDetailsAsync(id);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction("Index", "Error404");
            }

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
