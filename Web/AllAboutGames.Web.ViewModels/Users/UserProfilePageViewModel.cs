using System;
using System.Collections.Generic;
using System.Text;

namespace AllAboutGames.Web.ViewModels.Users
{
    public class UserProfilePageViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string DateOfBirth { get; set; }

        public string City { get; set; }

        public int ReviewsCount { get; set; }

        public int CommentsCount { get; set; }

        public string ProfilePicture { get; set; }
    }
}
