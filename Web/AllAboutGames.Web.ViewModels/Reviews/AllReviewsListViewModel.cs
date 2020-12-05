using System;
using System.Collections.Generic;
using System.Text;

namespace AllAboutGames.Web.ViewModels.Reviews
{
    public class AllReviewsListViewModel : PagingViewModel
    {
        public IEnumerable<AllReviewsViewModel> Reviews { get; set; }
    }
}
