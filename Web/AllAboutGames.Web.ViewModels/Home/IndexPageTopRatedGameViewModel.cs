namespace AllAboutGames.Web.ViewModels.Home
{
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;

    public class IndexPageTopRatedGameViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string DeveloperName { get; set; }

        public string Image { get; set; }

        public double Rating { get; set; }
    }
}
