namespace AllAboutGames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AllAboutGames.Common;
    using AllAboutGames.Data.Common.Models;

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
        [MaxLength(GlobalConstants.GameLanguageNameMaxLength)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<GameLanguage> GamesLanguages { get; set; }
    }
}
