using AllAboutGames.Data.Models;
using AllAboutGames.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllAboutGames.Web.ViewModels.ForumCategories
{
    public class CategoryViewModel : IMapFrom<ForumCategory>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<ForumPostInCategoryViewModel> ForumPosts { get; set; }
    }
}
