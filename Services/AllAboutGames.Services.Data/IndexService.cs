namespace AllAboutGames.Services.Data
{
    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Web.ViewModels.Home;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;
    using System.Linq;
    using System;
    using Microsoft.EntityFrameworkCore;

    public class IndexService : IIndexService
    {
        private readonly IDeletableEntityRepository<Game> gameRepository;
        private readonly IDeletableEntityRepository<Platform> platformRepository;
        private readonly IDeletableEntityRepository<Review> reviewRepository;
        private readonly IRatingsService ratingsService;

        public IndexService(
            IDeletableEntityRepository<Game> gameRepository,
            IDeletableEntityRepository<Platform> platformRepository,
            IDeletableEntityRepository<Review> reviewRepository,
            IRatingsService ratingsService)
        {
            this.gameRepository = gameRepository;
            this.platformRepository = platformRepository;
            this.reviewRepository = reviewRepository;
            this.ratingsService = ratingsService;
        }

        public IndexPageViewModel GetData()
        {
            var newestPlatform = this.platformRepository.All().OrderByDescending(x => x.ReleaseDate).FirstOrDefault();
            var topRatedGame = this.gameRepository.All().Include(x => x.Developer).OrderByDescending(x => x.Ratings.Average(r => r.Value)).FirstOrDefault();
            var recentReviews = this.reviewRepository.All().OrderByDescending(x => x.CreatedOn).Take(10);

            return new IndexPageViewModel
            {
                Platform = new IndexPageNewestPlatformViewModel
                {
                    Image = newestPlatform.Image,
                    Info = newestPlatform.Info,
                    Name = newestPlatform.Name,
                },
                TopRatedGame = new IndexPageTopRatedGameViewModel
                {
                    Id = topRatedGame.Id,
                    DeveloperName = topRatedGame.Developer.Name,
                    Image = topRatedGame.Image,
                    Name = topRatedGame.Name,
                    Rating = Math.Round(this.ratingsService.GetAverageRating(topRatedGame.Id), 1),
                },
                Reviews = this.reviewRepository.All().Select(x => new IndexPageReviewsViewModel
                {
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy"),
                    GameName = x.Game.Name,
                    GameRating = Math.Round(this.ratingsService.GetAverageRating(topRatedGame.Id), 1),
                    ReviewedByUserName = x.ReviewedBy.UserName,
                }),
            };
        }
    }
}
