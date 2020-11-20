namespace AllAboutGames.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Models;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Platforms;

    public interface IPlatformsService
    {
        Task AddPlatformAsync(AddPlatformInputModel model);

        bool CheckIfPlatformExists(string name);

        IEnumerable<AllGamesByPlatformViewModel> GetAllGamesByPlatform(string platform);
    }
}
