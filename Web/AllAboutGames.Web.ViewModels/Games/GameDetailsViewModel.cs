using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AllAboutGames.Web.ViewModels.Games
{
    public class GameDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Summary { get; set; }

        public string Image { get; set; }

        public int RatingsCount { get; set; }

        public double AverageRating { get; set; }

        public string Website { get; set; }

        public string Developer { get; set; }

        public string TrailerUrl { get; set; }

        public string ReleaseDate { get; set; }

        public string Languages { get; set; }

        public string Platforms { get; set; }

        public string Genres { get; set; }

        [Required(ErrorMessage = "Review text should contain at least 4 characters.")]
        public string ReviewText { get; set; }

        public IEnumerable<GameCommentsViewModel> Comments { get; set; }
    }
}
