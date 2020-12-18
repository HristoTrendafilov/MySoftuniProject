namespace AllAboutGames.Web.ViewModels.Games
{
    using System.Collections.Generic;

    using AllAboutGames.Data.Models;
    using AllAboutGames.Web.ViewModels.Game;

    public class EditGameViewModel : AddGameViewModel
    {
        public IEnumerable<Platform> GamePlatforms { get; set; }

        public IEnumerable<Genre> GameGenres { get; set; }

        public IEnumerable<Language> GameLanguages { get; set; }
    }
}
