namespace AllAboutGames.Web.ViewModels.Game
{
    using System.Collections.Generic;

    using AllAboutGames.Data.Models;

    public class CreateGameViewModel
    {
        public IEnumerable<Platform> Platforms { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<Language> Languages { get; set; }
    }
}
