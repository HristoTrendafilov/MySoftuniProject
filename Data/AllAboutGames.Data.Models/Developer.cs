namespace AllAboutGames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AllAboutGames.Common;
    using AllAboutGames.Data.Common.Models;

    public class Developer : IDeletableEntity
    {
        public Developer()
        {
            this.Games = new HashSet<Game>();
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DeveloperNameMaxLength)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
