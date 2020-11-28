namespace AllAboutGames.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Web.ViewModels.Users;

    public interface IUsersService
    {
        IEnumerable<KeyValuePair<string, string>> GetRoles();

        AddUserToRoleViewModel GetDataForRoleAdding();

        IEnumerable<KeyValuePair<string,string>> GetUsers();

        Task AddUserToRole(AddUserToRoleInputModel model);
    }
}
