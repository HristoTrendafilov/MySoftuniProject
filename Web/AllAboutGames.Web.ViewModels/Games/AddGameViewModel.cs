namespace AllAboutGames.Web.ViewModels.Game
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AllAboutGames.Data.Models;
    using Microsoft.AspNetCore.Http;

    public class AddGameViewModel
    {
        [MinLength(3)]
        [MaxLength(300)]
        [Required(ErrorMessage = "Name should be between 3 and 300 characters.")]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        [Required(ErrorMessage = "Price can't be negative number.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public IFormFile Image { get; set; }

        public string Website { get; set; }

        public string Trailer { get; set; }

        [MinLength(10)]
        [Required(ErrorMessage = "Summary should have atleast 10 characters.")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Release date is required.")]
        public DateTime ReleaseDate { get; set; }

        [MinLength(3)]
        [MaxLength(200)]
        [Required(ErrorMessage = "Developer name should be between 3 and 200 characters.")]
        public string Developer { get; set; }

        [Required(ErrorMessage = "Select platform.")]
        public IEnumerable<Platform> Platforms { get; set; }

        [Required(ErrorMessage = "Select genre.")]
        public IEnumerable<Genre> Genres { get; set; }

        [Required(ErrorMessage = "Select language.")]
        public IEnumerable<Language> Languages { get; set; }
    }
}
