using System.ComponentModel.DataAnnotations;

namespace AllAboutGames.Web.ViewModels.InputModels
{
    public class AddReviewInputModel
    {
        public string GameId { get; set; }

        public string UserId { get; set; }

        [MinLength(4)]
        [Required(ErrorMessage = "Review must be atleast 4 characters.")]
        public string Text { get; set; }
    }
}
