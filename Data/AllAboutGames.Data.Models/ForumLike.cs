namespace AllAboutGames.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ForumLike
    {
        public ForumLike()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey(nameof(ForumPost))]
        public string ForumPostId { get; set; }

        public ForumPost ForumPost { get; set; }
    }
}
