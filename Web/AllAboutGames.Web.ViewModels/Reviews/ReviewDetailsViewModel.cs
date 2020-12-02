using System;
using System.Collections;
using System.Collections.Generic;

namespace AllAboutGames.Web.ViewModels.Reviews
{
    public class ReviewDetailsViewModel
    {
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
