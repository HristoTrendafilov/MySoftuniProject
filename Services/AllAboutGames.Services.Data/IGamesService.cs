namespace AllAboutGames.Services.Data
{
    using System.Threading.Tasks;

    using AllAboutGames.Web.ViewModels.Game;
    using AllAboutGames.Web.ViewModels.Games;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.AspNetCore.Http;

    public interface IGamesService
    {
        Task<AddGameViewModel> GetAllInfoAsync();

        Task AddGameAsync(AddGameInputModel model, string rootPath);

        Task<GameDetailsViewModel> GetDetailsAsync(string id);

        Task EditGameAsync(string id, EditGameInputModel model, string rootPath);

        Task DeleteGameAsync(string id);

        Task CheckIfGameExistsByIdAsync(string id);

        Task<EditGameViewModel> GetEditModel(string id);
    }
}
