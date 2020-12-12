using AllAboutGames.Data.Models;
using AllAboutGames.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllAboutGames.Web.ViewModels.ForumPosts
{
    public class CategoryDropDownViewModel : IMapFrom<ForumCategory>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
