namespace AllAboutGames.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Users;

    public interface IUsersService
    {
        IEnumerable<KeyValuePair<string, string>> GetRoles();

        AddUserToRoleViewModel GetDataForRoleAdding();

        IEnumerable<KeyValuePair<string, string>> GetUsers();

        Task AddUserToRole(AddUserToRoleInputModel model);

        Task<UserProfilePageViewModel> GetUserDetailsAsync(string id);

        Task ChangeProfilePictureAsync(AddProfilePictureToUserInputModel model, string rootPath);
    }
}
