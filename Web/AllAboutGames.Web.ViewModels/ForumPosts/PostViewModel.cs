using AllAboutGames.Data.Models;
using AllAboutGames.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllAboutGames.Web.ViewModels.ForumPosts
{
    public class PostViewModel : IMapFrom<ForumPost>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string UserId { get; set; }

        public string UserProfilePicture { get; set; }

        public string UserUserName { get; set; }

        public string ForumCategoryId { get; set; }

        public string Content { get; set; }

        public int UserForumPostsCount { get; set; }

        public DateTime UserCreatedOn { get; set; }

        public string UserCreatedOnAsString => this.UserCreatedOn.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

        public int ForumCommentsCount { get; set; }

        public int ForumLikesCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => this.CreatedOn.ToString("dd/MM/yyyy hh:mm", System.Globalization.CultureInfo.InvariantCulture);

        public IEnumerable<ForumPostCommentViewModel> ForumComments { get; set; }
    }
}
