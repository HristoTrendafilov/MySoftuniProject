namespace AllAboutGames.Web.ViewModels.Game
{
    using System;
    using System.Collections.Generic;

    using AllAboutGames.Data.Models;
    using Microsoft.AspNetCore.Http;

    public class AddGameViewModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public IFormFile Image { get; set; }

        public string Website { get; set; }

        public string Trailer { get; set; }

        public string Summary { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Developer { get; set; }

        public IEnumerable<Platform> Platforms { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<Language> Languages { get; set; }
    }
}
