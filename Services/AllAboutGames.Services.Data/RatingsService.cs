namespace AllAboutGames.Services.Data
{
    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using System.Linq;
    using System.Threading.Tasks;

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
            var averageRating = this.ratingsRepository.All().Where(x => x.GameId == gameId).Average(x => x.Value);

            return averageRating;
        }

        public async Task SetRatingAsync(string gameId, string userId, int value)
        {
            var rating = this.ratingsRepository.All().FirstOrDefault(x => x.GameId == gameId && x.UserId == userId);
            var game = this.gameRepository.All().FirstOrDefault(x => x.Id == gameId);

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
