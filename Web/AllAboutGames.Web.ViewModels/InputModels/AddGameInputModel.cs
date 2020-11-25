namespace AllAboutGames.Web.ViewModels.InputModels
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddGameInputModel
    {
        [MinLength(3)]
        [MaxLength(300)]
        [Required(ErrorMessage = "Name should be between 3 and 300 characters.")]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        [Required(ErrorMessage = "Price can't be negative number.")]
        public double Price { get; set; }

        public IFormFile Image { get; set; }

        [Url]
        [Required(ErrorMessage = "Invalid Url.")]
        public string Website { get; set; }

        [Url]
        [Required(ErrorMessage = "Invalid Url.")]
        public string Trailer { get; set; }

        public DateTime ReleaseDate { get; set; }

        [MinLength(3)]
        [MaxLength(200)]
        [Required(ErrorMessage = "Developer name should be between 3 and 200 characters.")]
        public string Developer { get; set; }

        public string[] Languages { get; set; }

        public string[] Genres { get; set; }

        public string[] Platforms { get; set; }

        [MinLength(10)]
        [Required(ErrorMessage = "Summary should have atleast 10 characters.")]
        public string Summary { get; set; }
    }
}
