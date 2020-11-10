namespace AllAboutGames.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Data.InputModels;
    using AllAboutGames.Web.ViewModels.Game;

    public interface IGamesService
    {
        CreateGameViewModel GetAllInfo();

        Task AddGameAsync(AddGameInputModel model);
    }
}
