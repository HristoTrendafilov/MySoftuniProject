namespace AllAboutGames.Web.ViewModels.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;
    using AllAboutGames.Web.ViewModels.ForumPosts;

    public class AddForumPostInputModel : IMapFrom<ForumPost>
    {
        [Required(ErrorMessage = "Title should be between 4 and 300 characters.")]
        [MinLength(4)]
        [MaxLength(300)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content should be atleast 10 characters")]
        [MinLength(10)]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Select the Category you want to add the post")]
        public string ForumCategoryId { get; set; }

        public IEnumerable<CategoryDropDownViewModel> ForumCategories { get; set; }
    }
}
