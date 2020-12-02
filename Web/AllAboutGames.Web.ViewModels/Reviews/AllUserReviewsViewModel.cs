using System;
using System.Collections.Generic;
using System.Text;

namespace AllAboutGames.Web.ViewModels.Reviews
{
    public class AllUserReviewsViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string CreatedOn { get; set; }

        public string Text { get; set; }

        public int Rating { get; set; }
    }
}
