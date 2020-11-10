namespace AllAboutGames.Services.Data
{
    using System.Threading.Tasks;

    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Data.InputModels;

    public interface IPlatformsService
    {
        Task<Platform> AddPlatformAsync(AddPlatformInputModel model);

        bool CheckIfPlatformExists(string name);
    }
}
