using Microsoft.AspNetCore.Http;
using System;

namespace AllAboutGames.Web.ViewModels.Platforms
{
    public class CreatePlatformViewModel
    {
        public string Name { get; set; }

        public IFormFile Image { get; set; }

        public string Info { get; set; }

        public string Developer { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
