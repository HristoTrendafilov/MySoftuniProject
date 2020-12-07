namespace AllAboutGames.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using AllAboutGames.Data.Common.Models;

    public class ForumCategory : IDeletableEntity
    {
        public ForumCategory()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ForumPosts = new HashSet<ForumPost>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<ForumPost> ForumPosts { get; set; }
    }
}
