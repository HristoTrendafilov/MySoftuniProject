namespace AllAboutGames.Web.ViewModels.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class PostRatingInputModel
    {
        public string GameId { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }
    }
}
