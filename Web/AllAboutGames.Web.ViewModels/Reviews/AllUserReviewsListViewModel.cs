using System;
using System.Collections.Generic;
using System.Text;

namespace AllAboutGames.Web.ViewModels.Reviews
{
    public class AllUserReviewsListViewModel : PagingViewModel
    {
        public ReviewDetailsViewModel Reviews { get; set; }
    }
}
