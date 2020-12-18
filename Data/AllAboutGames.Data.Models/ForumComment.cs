namespace AllAboutGames.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AllAboutGames.Data.Common.Models;

    public class ForumComment : IDeletableEntity
    {
        public ForumComment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Text { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(ForumPost))]
        public string ForumPostId { get; set; }

        public ForumPost ForumPost { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
