namespace AllAboutGames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using AllAboutGames.Data.Common.Models;

    public class ForumPost : IDeletableEntity
    {
        public ForumPost()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ForumComments = new HashSet<ForumComment>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(ForumCategory))]
        public string ForumCategoryId { get; set; }

        public ForumCategory ForumCategory { get; set; }

        public virtual ICollection<ForumComment> ForumComments { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn => DateTime.UtcNow;
    }
}
