namespace AllAboutGames.Web.ViewModels.Users
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AllAboutGames.Data.Models;

    public class AddUserToRoleViewModel
    {
        public IEnumerable<KeyValuePair<string, string>> Users { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Roles { get; set; }
    }
}
