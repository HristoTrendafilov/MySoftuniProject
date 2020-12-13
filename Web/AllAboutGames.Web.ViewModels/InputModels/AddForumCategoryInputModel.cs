using AllAboutGames.Data.Models;
using AllAboutGames.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AllAboutGames.Web.ViewModels.InputModels
{
    public class AddForumCategoryInputModel : IMapFrom<ForumCategory>
    {
        [Required(ErrorMessage = "Category name should be atleast 4 characters.")]
        [MinLength(4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Choose image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Description should be atlease 4 characters.")]
        [MinLength(4)]
        public string Description { get; set; }
    }
}
