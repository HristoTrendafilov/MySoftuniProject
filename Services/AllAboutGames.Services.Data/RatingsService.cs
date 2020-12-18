namespace AllAboutGames.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class RatingsService : IRatingsService
    {
        private readonly IRepository<Rating> ratingsRepository;
        private readonly IDeletableEntityRepository<Game> gameRepository;

        public RatingsService(IRepository<Rating> ratingsRepository, IDeletableEntityRepository<Game> gameRepository)
        {
            this.ratingsRepository = ratingsRepository;
            this.gameRepository = gameRepository;
        }

        public double GetAverageRating(string gameId)
        {
            var rating = this.ratingsRepository.All()
                .Where(x => x.GameId == gameId);

            if (rating == null)
            {
                return 0;
            }

            return Math.Round(rating.Average(x => x.Value), 1);
        }

        public async Task SetRatingAsync(string gameId, string userId, int value)
        {
            var rating = await this.ratingsRepository.All()
                .FirstOrDefaultAsync(x => x.GameId == gameId && x.UserId == userId);

            var game = await this.gameRepository.All()
                .FirstOrDefaultAsync(x => x.Id == gameId);

            if (rating == null)
            {
                rating = new Rating
                {
                    GameId = gameId,
                    UserId = userId,
                };

                await this.ratingsRepository.AddAsync(rating);

                game.RatingsCount++;
                await this.gameRepository.SaveChangesAsync();
            }

            rating.Value = value;
            await this.ratingsRepository.SaveChangesAsync();
        }
    }
}
