namespace AllAboutGames.Web.ViewModels.Home
{
    using AllAboutGames.Data.Models;

    using AllAboutGames.Services.Mapping;
    using AutoMapper;
    using System.Linq;

    public class IndexPageReviewsViewModel
    {
        public string Id { get; set; }

        public string GameId { get; set; }

        public string ReviewedByUserName { get; set; }

        public string GameName { get; set; }

        public double GameRating { get; set; }

        public string CreatedOn { get; set; }
    }
}
