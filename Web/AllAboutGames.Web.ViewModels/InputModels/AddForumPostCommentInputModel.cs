namespace AllAboutGames.Web.ViewModels.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddForumPostCommentInputModel
    {
        [Required]
        public string Text { get; set; }

        public string PostId { get; set; }
    }
}
