namespace AllAboutGames.Web.ViewModels.ForumPosts
{
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<ForumCategory>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
