namespace AllAboutGames.Web.ViewModels.Home
{
    using System.Collections;
    using System.Collections.Generic;

    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;

    public class IndexPageViewModel
    {
        public IndexPageTopRatedGameViewModel TopRatedGame { get; set; }

        public IEnumerable<IndexPageReviewsViewModel> Reviews { get; set; }

        public IndexPageNewestPlatformViewModel Platform { get; set; }
    }
}
