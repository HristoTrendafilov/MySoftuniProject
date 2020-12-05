﻿namespace AllAboutGames.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddPlatformInputModel
    {
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int GamesCount { get; set; }

        [Url]
        public string Image { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string CreatedBy { get; set; }
    }
}
