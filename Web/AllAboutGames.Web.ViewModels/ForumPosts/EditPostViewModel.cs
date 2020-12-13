using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AllAboutGames.Web.ViewModels.ForumPosts
{
    public class EditPostViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        [Display(Name = "Category")]
        public string ForumCategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> ForumCategories { get; set; }
    }
}
