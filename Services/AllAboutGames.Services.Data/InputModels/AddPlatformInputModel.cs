namespace AllAboutGames.Services.Data.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AllAboutGames.Services.Data.CustomAttributes;

    public class AddPlatformInputModel
    {
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [ValidUrl]
        public string Image { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string Developer { get; set; }

        [MinLength(5)]
        public string Info { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
