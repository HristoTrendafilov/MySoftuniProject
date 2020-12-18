namespace AllAboutGames.Web.ViewModels.ForumCategories
{
    using System.Collections.Generic;

    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;

    public class CategoryViewModel : IMapFrom<ForumCategory>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PageNumber { get; set; }

        public int ForumPostsCount { get; set; }

        public IEnumerable<ForumPostInCategoryViewModel> Posts { get; set; }
    }
}
