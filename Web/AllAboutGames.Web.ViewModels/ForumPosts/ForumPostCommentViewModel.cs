using AllAboutGames.Data.Models;
using AllAboutGames.Services.Mapping;
using System;

namespace AllAboutGames.Web.ViewModels.ForumPosts
{
    public class ForumPostCommentViewModel : IMapFrom<ForumComment>
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }

        public string UserProfilePicture { get; set; }

        public int UserForumPostsCount { get; set; }

        public DateTime UserCreatedOn { get; set; }

        public string UserCreatedOnAsString => this.UserCreatedOn.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => this.CreatedOn.ToString("dd/MM/yyyy hh:mm", System.Globalization.CultureInfo.InvariantCulture);

        public string UserUserName { get; set; }
    }
}