namespace AllAboutGames.Web.ViewModels.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;

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
