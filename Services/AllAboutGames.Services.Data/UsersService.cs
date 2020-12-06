﻿namespace AllAboutGames.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using AllAboutGames.Services.Mapping;

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

            var profilePicture = await this.UploadedFile(model.ProfilePicture, model.Username, rootPath);

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
            return this.roleRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public async Task<UserProfilePageViewModel> GetUserDetailsAsync(string id)
        {
            return await this.userRepository.All()
                .Where(x => x.Id == id)
                .To<UserProfilePageViewModel>()
                .FirstOrDefaultAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetUsers()
        {
            return this.userRepository.All().Select(x => new
            {
                x.Id,
                x.UserName,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.UserName));
        }

        private async Task<string> UploadedFile(IFormFile image, string userName, string rootPath)
        {
            var fileName = Path.GetFileName(image.FileName);
            var directory = $"{rootPath}\\images\\users\\{userName}";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{rootPath}\\images\\users\\{userName}", fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileSteam);
            }

            return $"\\images\\users\\{userName}\\{fileName}";
        }
    }
}
