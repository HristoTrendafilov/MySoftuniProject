using AllAboutGames.Data.Common.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllAboutGames.Data.Models
{
    public class ForumComment : IDeletableEntity
    {
        public ForumComment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [ForeignKey(nameof(ForumPost))]
        public string ForumPostId { get; set; }

        public ForumPost ForumPost { get; set; }

        public string Text { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn => DateTime.UtcNow;
    }
}
