namespace AllAboutGames.Web.ViewModels.Reviews
{
    using System.Collections.Generic;

    public class AllReviewsListViewModel : PagingViewModel
    {
        public IEnumerable<AllReviewsViewModel> Reviews { get; set; }
    }
}