namespace AllAboutGames.Services.Data
{
    using System.Threading.Tasks;
    using AllAboutGames.Web.ViewModels.Game;
    using AllAboutGames.Web.ViewModels.Games;
    using AllAboutGames.Web.ViewModels.InputModels;

    public interface IGamesService
    {
        AddGameViewModel GetAllInfo();

        Task AddGameAsync(AddGameInputModel model);

        GameDetailsViewModel GetDetails(string id);
    }
}
