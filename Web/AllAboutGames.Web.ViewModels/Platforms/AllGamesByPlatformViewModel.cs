namespace AllAboutGames.Web.ViewModels.Platforms
{
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;

    public class AllGamesByPlatformViewModel : IMapFrom<Game>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int PageNumber { get; set; }

        public int GamesCount { get; set; }
    }
}
