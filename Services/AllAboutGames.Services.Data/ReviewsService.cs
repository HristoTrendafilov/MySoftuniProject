namespace AllAboutGames.Services.Data
{
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

        public ReviewsService(
            IDeletableEntityRepository<Review> reviewRepository,
            IDeletableEntityRepository<Game> gameRepository)
        {
            this.reviewRepository = reviewRepository;
            this.gameRepository = gameRepository;
        }

        public async Task AddAsync(AddReviewInputModel model)
        {
            var review = await this.reviewRepository.All().FirstOrDefaultAsync(x => x.GameId == model.GameId && x.UserId == model.UserId);

            if (review == null)
            {
                review = new Review
                {
                    GameId = model.GameId,
                    UserId = model.UserId,
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
    }
}
