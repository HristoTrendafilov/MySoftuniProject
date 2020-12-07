namespace AllAboutGames.Web.ViewModels.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class AddProfilePictureToUserInputModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public IFormFile ProfilePicture { get; set; }
    }
}
