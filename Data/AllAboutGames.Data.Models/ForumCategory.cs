namespace AllAboutGames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AllAboutGames.Common;
    using AllAboutGames.Data.Common.Models;

    public class ForumCategory : IDeletableEntity
    {
        public ForumCategory()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ForumPosts = new HashSet<ForumPost>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ForumCategoryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<ForumPost> ForumPosts { get; set; }
    }
}
