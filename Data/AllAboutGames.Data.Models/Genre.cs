namespace AllAboutGames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AllAboutGames.Common;
    using AllAboutGames.Data.Common.Models;

    public class Genre : IDeletableEntity
    {
        public Genre()
        {
            this.GamesGenres = new HashSet<GameGenre>();
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.GameGenreNameMaxLength)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<GameGenre> GamesGenres { get; set; }
    }
}
