namespace AllAboutGames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AllAboutGames.Common;
    using AllAboutGames.Data.Common.Models;

    public class Platform : IDeletableEntity
    {
        public Platform()
        {
            this.GamesPlatforms = new HashSet<GamePlatform>();
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlatformNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Info { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Developer))]
        public string DeveloperId { get; set; }

        public Developer Developer { get; set; }

        public virtual ICollection<GamePlatform> GamesPlatforms { get; set; }
    }
}
