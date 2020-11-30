﻿namespace AllAboutGames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AllAboutGames.Data.Common.Models;

    public class Game : IDeletableEntity
    {
        public Game()
        {
            this.GamesPlatforms = new HashSet<GamePlatform>();
            this.GamesGenres = new HashSet<GameGenre>();
            this.GamesLanguages = new HashSet<GameLanguage>();

            this.Reviews = new HashSet<Review>();
            this.Ratings = new HashSet<Rating>();
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(300)]
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

        [Required]
        [ForeignKey(nameof(Developer))]
        public string DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<CommentForGame> Comments { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<GameLanguage> GamesLanguages { get; set; }

        public virtual ICollection<GamePlatform> GamesPlatforms { get; set; }

        public virtual ICollection<GameGenre> GamesGenres { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
