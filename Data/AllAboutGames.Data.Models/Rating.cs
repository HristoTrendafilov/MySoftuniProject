namespace AllAboutGames.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AllAboutGames.Data.Common.Models;

    public class Rating : BaseModel<int>
    {
        [Required]
        [ForeignKey(nameof(Game))]
        public string GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int Value { get; set; }
    }
}
