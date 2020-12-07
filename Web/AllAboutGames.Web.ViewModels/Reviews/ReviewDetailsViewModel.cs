namespace AllAboutGames.Web.ViewModels.Reviews
{
    using System.Collections.Generic;

    public class ReviewDetailsViewModel
    {
        public string GameId { get; set; }

        public string GameName { get; set; }

        public double AverageRating { get; set; }

        public string OneStarRatingPercent { get; set; }

        public string TwoStarRatingPercent { get; set; }

        public string ThreeStarRatingPercent { get; set; }

        public string FourStarRatingPercent { get; set; }

        public string FiveStarRatingPercent { get; set; }

        public virtual IEnumerable<AllUserReviewsViewModel> UserReviews { get; set; }
    }
}
