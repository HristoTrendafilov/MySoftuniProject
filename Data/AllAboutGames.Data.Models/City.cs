namespace AllAboutGames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AllAboutGames.Common;

    public class City
    {
        public City()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CityNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(Country))]
        public string CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
