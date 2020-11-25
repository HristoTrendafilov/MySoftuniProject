using System;
using System.Collections.Generic;
using System.Text;

namespace AllAboutGames.Web.ViewModels.Platforms
{
    public class AllGamesListViewModel : PagingViewModel
    {
        public IEnumerable<AllGamesByPlatformViewModel> Games { get; set; }
    }
}
