namespace AllAboutGames.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AllAboutGames.Data.Common.Models;

    public class FeedBack : IDeletableEntity
    {
        public FeedBack()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
