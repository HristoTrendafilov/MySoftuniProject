namespace AllAboutGames.Data.Models
{
    using AllAboutGames.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Language : IDeletableEntity
    {
        public Language()
        {
            this.GamesLanguages = new HashSet<GameLanguage>();
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<GameLanguage> GamesLanguages { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
