namespace AllAboutGames.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRatingsService
    {
        Task SetRatingAsync(string gameId, string userId, int value);

        double GetAverageRating(string gameId);
    }
}
