namespace AllAboutGames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AllAboutGames.Common;

    public class Country
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CountryNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
