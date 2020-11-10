namespace AllAboutGames.Data.Models
{
    using AllAboutGames.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
