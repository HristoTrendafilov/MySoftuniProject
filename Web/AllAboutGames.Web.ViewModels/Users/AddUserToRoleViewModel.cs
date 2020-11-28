using AllAboutGames.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AllAboutGames.Web.ViewModels.Users
{
    public class AddUserToRoleViewModel
    {
        public IEnumerable<KeyValuePair<string, string>> Users { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Roles { get; set; }
    }
}
