namespace AllAboutGames.Web.ViewModels.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public class AddPlatformInputModel
    {
        [MinLength(3)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Name should be between 3 and 100 characters.")]
        public string Name { get; set; }

        [Url]
        [Required(ErrorMessage = "Invalid Url.")]
        public string Image { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Developer name should be between 3 and 100 characters.")]
        public string Developer { get; set; }

        [MinLength(5)]
        [Required(ErrorMessage = "Info should be atleast 5 characters.")]
        public string Info { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
