using AllAboutGames.Services.Data;
using AllAboutGames.Web.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AllAboutGames.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AddToRole()
        {
            var viewModel = this.usersService.GetDataForRoleAdding();
            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
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
    }
}
