using System.ComponentModel.DataAnnotations;

namespace AllAboutGames.Web.ViewModels.InputModels
{
    public class PostRatingInputModel
    {
        public string GameId { get; set; }

        [Range(1, 5)]
        public int Value { get; set; }
    }
}
