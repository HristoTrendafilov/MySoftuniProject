using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllAboutGames.Web.ViewModels.InputModels
{
    public class AddProfilePictureToUserInputModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public IFormFile ProfilePicture { get; set; }
    }
}
