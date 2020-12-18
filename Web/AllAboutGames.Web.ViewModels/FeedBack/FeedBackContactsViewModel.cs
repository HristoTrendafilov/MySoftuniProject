namespace AllAboutGames.Web.ViewModels.FeedBack
{
    using System.ComponentModel.DataAnnotations;

    public class FeedBackContactsViewModel
    {
        [Required(ErrorMessage = "Text should be atleast 5 characters.")]
        [MinLength(5)]
        public string Text { get; set; }

        [Required(ErrorMessage = "About should be atleast 5 characters.")]
        [MinLength(5)]
        public string About { get; set; }
    }
}
