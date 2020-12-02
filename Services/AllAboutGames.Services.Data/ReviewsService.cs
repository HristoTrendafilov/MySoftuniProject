namespace AllAboutGames.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Reviews;
    using Microsoft.EntityFrameworkCore;

    public class ReviewsService : IReviewsService
    {
        private readonly IDeletableEntityRepository<Review> reviewRepository;
        private readonly IDeletableEntityRepository<Game> gameRepository;
        private readonly IRepository<Rating> ratingRepository;
        private readonly IRatingsService ratingsService;

        public ReviewsService(
            IDeletableEntityRepository<Review> reviewRepository,
            IDeletableEntityRepository<Game> gameRepository,
            IRepository<Rating> ratingRepository,
            IRatingsService ratingsService)
        {
            this.reviewRepository = reviewRepository;
            this.gameRepository = gameRepository;
            this.ratingRepository = ratingRepository;
            this.ratingsService = ratingsService;
        }

        public async Task AddAsync(AddReviewInputModel model)
        {
            var review = await this.reviewRepository.All()
                .FirstOrDefaultAsync(x => x.GameId == model.GameId && x.UserId == model.UserId);

            if (review == null)
            {
                var ratingId = this.ratingRepository.AllAsNoTracking()
                    .FirstOrDefault(x => x.GameId == model.GameId && x.UserId == model.UserId).Id;

                review = new Review
                {
                    GameId = model.GameId,
                    UserId = model.UserId,
                    RatingId = ratingId,
                };

                await this.reviewRepository.AddAsync(review);
            }

            review.Text = model.Text;
            await this.reviewRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllReviewsViewModel>> GetAllAsync()
        {
            return await this.gameRepository.All().Where(x => x.Reviews.Count > 0)
                .To<AllReviewsViewModel>()
                .ToListAsync();
        }

        public async Task<ReviewDetailsViewModel> GetReviewDetailsAsync(string id)
        {
            var game = await this.gameRepository
                .AllAsNoTracking()
                .Include(x => x.Ratings)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (game == null)
            {
                throw new ArgumentException("Game does not exist.");
            }

            var totalRatings = game.RatingsCount;

            var fiveStarRating = ((double)game.Ratings.Where(x => x.Value == 5).Count() / totalRatings) * 100;
            var fourStarRating = ((double)game.Ratings.Where(x => x.Value == 4).Count() / totalRatings) * 100;
            var threeStarRating = ((double)game.Ratings.Where(x => x.Value == 3).Count() / totalRatings) * 100;
            var twoStarRating = ((double)game.Ratings.Where(x => x.Value == 2).Count() / totalRatings) * 100;
            var oneStarRating = ((double)game.Ratings.Where(x => x.Value == 1).Count() / totalRatings) * 100;


            var viewModel = new ReviewDetailsViewModel
            {
                GameName = game.Name,
                AverageRating = this.ratingsService.GetAverageRating(id),
                OneStarRatingPercent = oneStarRating.ToString() + "%",
                TwoStarRatingPercent = twoStarRating.ToString() + "%",
                ThreeStarRatingPercent = threeStarRating.ToString() + "%",
                FourStarRatingPercent = fourStarRating.ToString() + "%",
                FiveStarRatingPercent = fiveStarRating.ToString() + "%",
                UserReviews = this.reviewRepository.AllAsNoTracking().Where(x => x.GameId == id).Select(x => new AllUserReviewsViewModel
                {
                    Id = x.UserId,
                    Username = x.ReviewedBy.UserName,
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy"),
                    Text = x.Text,
                    Rating = x.Rating.Value,
                }),
            };

            return viewModel;
        }
    }
}
