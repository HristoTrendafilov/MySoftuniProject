﻿using AllAboutGames.Data.Models;
using AllAboutGames.Services.Mapping;
using Ganss.XSS;

namespace AllAboutGames.Web.ViewModels.Forum
{
    public class IndexCategoryViewMode : IMapFrom<ForumCategory>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int ForumPostsCount { get; set; }
    }
}