using AllAboutGames.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AllAboutGames.Data.Models
{
    public class ForumLike
    {
        public ForumLike()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey(nameof(ForumPost))]
        public string ForumPostId { get; set; }

        public ForumPost ForumPost { get; set; }
    }
}
