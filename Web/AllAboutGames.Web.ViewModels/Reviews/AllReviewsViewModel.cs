namespace AllAboutGames.Web.ViewModels.Reviews
{
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;

    public class AllReviewsViewModel : IMapFrom<Game>
    {
        public string Id { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public string DeveloperName { get; set; }
    }
}
