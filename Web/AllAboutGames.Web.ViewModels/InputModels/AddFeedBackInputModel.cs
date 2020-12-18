namespace AllAboutGames.Web.ViewModels.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddFeedBackInputModel
    {
        [Required(ErrorMessage = "Text should be atleast 5 characters.")]
        [MinLength(5)]
        public string Text { get; set; }

        [Required(ErrorMessage = "About should be atleast 5 characters.")]
        [MinLength(5)]
        public string About { get; set; }
    }
}
