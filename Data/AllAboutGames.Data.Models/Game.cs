namespace AllAboutGames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AllAboutGames.Common;
    using AllAboutGames.Data.Common.Models;

    public class Game : IDeletableEntity
    {
        public Game()
        {
            this.GamePlatforms = new HashSet<GamePlatform>();
            this.GameGenres = new HashSet<GameGenre>();
            this.GameLanguages = new HashSet<GameLanguage>();

            this.Reviews = new HashSet<Review>();
            this.Ratings = new HashSet<Rating>();
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.GameNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Image { get; set; }

        public string Website { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int RatingsCount { get; set; }

        public string TrailerUrl { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Developer))]
        public string DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<GameLanguage> GameLanguages { get; set; }

        public virtual ICollection<GamePlatform> GamePlatforms { get; set; }

        public virtual ICollection<GameGenre> GameGenres { get; set; }
    }
}
