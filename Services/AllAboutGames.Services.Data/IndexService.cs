namespace AllAboutGames.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;
    using AllAboutGames.Web.ViewModels.Home;
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

        public async Task<IndexPageViewModel> GetDataAsync()
        {
            var newestPlatform = await this.platformRepository.All()
                .OrderByDescending(x => x.ReleaseDate)
                .FirstOrDefaultAsync();

            var topRatedGame = await this.gameRepository.All()
                .Include(x => x.Developer)
                .OrderByDescending(x => x.Ratings
                .Average(r => r.Value))
                .FirstOrDefaultAsync();

            var recentReviews = this.reviewRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Take(10);

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
                    Rating = this.ratingsService.GetAverageRating(topRatedGame.Id),
                },
                Reviews = recentReviews.Select(x => new IndexPageReviewsViewModel
                {
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy"),
                    GameName = x.Game.Name,
                    GameRating = this.ratingsService.GetAverageRating(topRatedGame.Id),
                    ReviewedByUserName = x.ReviewedBy.UserName,
                }),
            };
        }
    }
}
