using AllAboutGames.Data.Common.Repositories;
using AllAboutGames.Data.Models;
using AllAboutGames.Web.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AllAboutGames.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<ApplicationRole> roleRepository;
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(
            IRepository<ApplicationRole> roleRepository,
            IRepository<ApplicationUser> userRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        public IRepository<ApplicationUser> UserRepository { get; }

        public async Task AddUserToRole(AddUserToRoleInputModel model)
        {
            var user = this.userRepository.All().FirstOrDefault(x => x.UserName == model.Users);

            var isUserInRole = await this.userManager.IsInRoleAsync(user, model.Roles);

            if (isUserInRole)
            {
                return;
            }

            await this.userManager.AddToRoleAsync(user, model.Roles);
        }

        public AddUserToRoleViewModel GetDataForRoleAdding()
        {
            return new AddUserToRoleViewModel
            {
                Users = this.GetUsers(),
                Roles = this.GetRoles(),
            };
        }

        public IEnumerable<KeyValuePair<string, string>> GetRoles()
        {
            return this.roleRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string,string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<KeyValuePair<string, string>> GetUsers()
        {
            return this.userRepository.All().Select(x => new
            {
                x.Id,
                x.UserName,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.UserName));
        }

    }
}
