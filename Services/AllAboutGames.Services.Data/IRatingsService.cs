using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllAboutGames.Services.Data
{
    public interface IRatingsService
    {
        Task SetRatingAsync(string gameId, string userId, int value);

        double GetAverageRating(string gameId);
    }
}
