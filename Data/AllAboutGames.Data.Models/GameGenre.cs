namespace AllAboutGames.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GameGenre
    {
        [Required]
        [ForeignKey(nameof(Game))]
        public string GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(Genre))]
        public string GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
