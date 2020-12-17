using AllAboutGames.Data.Common.Repositories;
using AllAboutGames.Data.Models;
using AllAboutGames.Services.Mapping;
using AllAboutGames.Web.ViewModels.FeedBack;
using AllAboutGames.Web.ViewModels.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AllAboutGames.Services.Data
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IDeletableEntityRepository<FeedBack> feedBackRepository;

        public FeedBackService(IDeletableEntityRepository<FeedBack> feedBackRepository)
        {
            this.feedBackRepository = feedBackRepository;
        }

        public async Task AddAsync(AddFeedBackInputModel model, string userId)
        {
            var feedBack = new FeedBack
            {
                About = model.About,
                Text = model.Text,
                UserId = userId,
            };

            await this.feedBackRepository.AddAsync(feedBack);
            await this.feedBackRepository.SaveChangesAsync();

        }

        public async Task DeleteFeedBackAsync(string id)
        {
            var feedBack = await this.feedBackRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            feedBack.IsDeleted = true;
            feedBack.DeletedOn = DateTime.UtcNow;
            this.feedBackRepository.Update(feedBack);
            await this.feedBackRepository.SaveChangesAsync();
        }

        public IEnumerable<AllFeedBackViewModel> GetAll()
        {
            return this.feedBackRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .To<AllFeedBackViewModel>()
                .ToList();
        }
    }
}
