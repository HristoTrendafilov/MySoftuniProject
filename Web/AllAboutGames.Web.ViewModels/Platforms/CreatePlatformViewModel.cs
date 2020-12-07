namespace AllAboutGames.Web.ViewModels.Platforms
{
    using System;

    using Microsoft.AspNetCore.Http;

    public class CreatePlatformViewModel
    {
        public string Name { get; set; }

        public IFormFile Image { get; set; }

        public string Info { get; set; }

        public string Developer { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
