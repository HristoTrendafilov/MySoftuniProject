namespace AllAboutGames.Web.ViewModels.Platforms
{
    using AllAboutGames.Services.Mapping;
    using AllAboutGames.Data.Models;

    public class AllGamesByPlatformViewModel : IMapFrom<Game>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int PageNumber { get; set; }

        public int GamesCount { get; set; }
    }
}
