﻿namespace AllAboutGames.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AllAboutGames.Data.Common.Models;

    public class GameLanguage : IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

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
