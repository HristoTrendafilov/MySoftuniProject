namespace AllAboutGames.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Models;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Platforms;

    public interface IPlatformsService
    {
        Task AddPlatformAsync(AddPlatformInputModel model, string rootPath);

        Task CheckIfPlatformExistsByNameAsync(string name);

        Task<IEnumerable<AllGamesByPlatformViewModel>> GetAllGamesByPlatformAsync(string platform, int page, int itemsToShow = 12);

        int GetGamesCount(string platform);
    }
}
