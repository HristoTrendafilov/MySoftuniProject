namespace AllAboutGames.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GameLanguage
    {
        [Required]
        [ForeignKey(nameof(Game))]
        public string GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(Language))]
        public string LanguageId { get; set; }

        public virtual Language Language { get; set; }
    }
}
