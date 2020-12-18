namespace AllAboutGames.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AllAboutGames.Data.Common.Models;

    public class Review : IDeletableEntity
    {
        public Review()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public string GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(ReviewedBy))]
        public string UserId { get; set; }

        public virtual ApplicationUser ReviewedBy { get; set; }

        [Required]
        [ForeignKey(nameof(Rating))]
        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
