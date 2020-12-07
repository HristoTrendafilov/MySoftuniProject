namespace AllAboutGames.Web.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    public class AddUserToRoleInputModel
    {
        [Required(ErrorMessage = "Select username")]
        public string Users { get; set; }

        [Required(ErrorMessage = "Select role")]
        public string Roles { get; set; }
    }
}
