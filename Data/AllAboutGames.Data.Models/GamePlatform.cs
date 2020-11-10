namespace AllAboutGames.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GamePlatform
    {
        [Required]
        [ForeignKey(nameof(Game))]
        public string GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(Platform))]
        public string PlatformId { get; set; }

        public virtual Platform Platform { get; set; }
    }
}
