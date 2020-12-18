namespace AllAboutGames.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AllAboutGames.Common;
    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private const string MainFilePath = "users";

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

        public async Task AddUserToRole(AddUserToRoleInputModel model)
        {
            var user = await this.userRepository.All().FirstOrDefaultAsync(x => x.UserName == model.Users);

            var isUserInRole = await this.userManager.IsInRoleAsync(user, model.Roles);

            if (isUserInRole)
            {
                return;
            }

            await this.userManager.AddToRoleAsync(user, model.Roles);
        }

        public async Task ChangeProfilePictureAsync(AddProfilePictureToUserInputModel model, string rootPath)
        {
            var user = await this.userRepository.All().FirstOrDefaultAsync(x => x.Id == model.Id);

            var profilePicture = await GlobalMethods.UploadedFile(model.ProfilePicture, model.Username, rootPath, MainFilePath);

            user.ProfilePicture = profilePicture;
            await this.userRepository.SaveChangesAsync();
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
            return this.roleRepository.All()
                .Select(x => new
            {
                x.Id,
                x.Name,
            })
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public async Task<UserProfilePageViewModel> GetUserDetailsAsync(string id)
        {
            var user = await this.userRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new ArgumentException("User does not exist.");
            }

            return await this.userRepository.All()
                .Where(x => x.Id == id)
                .To<UserProfilePageViewModel>()
                .FirstOrDefaultAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetUsers()
        {
            return this.userRepository.All()
                .Select(x => new
            {
                x.Id,
                x.UserName,
            })
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.UserName));
        }
    }
}
