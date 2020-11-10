namespace AllAboutGames.Data.Models
{
    using AllAboutGames.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<GameGenre> GamesGenres { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
