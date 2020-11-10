namespace AllAboutGames.Services.Data.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AllAboutGames.Services.Data.CustomAttributes;

    public class AddGameInputModel
    {
        [MinLength(3)]
        [MaxLength(300)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [ValidUrl]
        public string Image { get; set; }

        [ValidUrl]
        public string Website { get; set; }

        public DateTime ReleaseDate { get; set; }

        [MinLength(3)]
        [MaxLength(200)]
        public string Developer { get; set; }

        [MinLength(3)]
        [MaxLength(200)]
        public string Publisher { get; set; }

        public string[] Tag { get; set; }

        public string[] Genre { get; set; }

        public string[] Language { get; set; }

        public string[] Platform { get; set; }

        [MinLength(10)]
        public string Summary { get; set; }
    }
}
