namespace AllAboutGames.Web.ViewModels.Platforms
{
    using System.Collections.Generic;

    public class AllGamesListViewModel : PagingViewModel
    {
        public IEnumerable<AllGamesByPlatformViewModel> Games { get; set; }
    }
}
