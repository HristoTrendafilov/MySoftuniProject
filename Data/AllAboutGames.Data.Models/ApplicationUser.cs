// ReSharper disable VirtualMemberCallInConstructor
namespace AllAboutGames.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AllAboutGames.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();

            this.Ratings = new HashSet<Rating>();
            this.Reviews = new HashSet<Review>();
            this.ForumPosts = new HashSet<ForumPost>();
            this.FeedBacks = new HashSet<FeedBack>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [ForeignKey(nameof(City))]
        public string CityId { get; set; }

        public City City { get; set; }

        public string ProfilePicture { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<ForumPost> ForumPosts { get; set; }

        public virtual ICollection<ForumComment> ForumComments { get; set; }

        public virtual ICollection<FeedBack> FeedBacks { get; set; }
    }
}
