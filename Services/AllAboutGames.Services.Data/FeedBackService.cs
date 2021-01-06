namespace AllAboutGames.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;
    using AllAboutGames.Web.ViewModels.FeedBack;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.EntityFrameworkCore;

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

            if (feedBack == null)
            {
                throw new ArgumentException("Feedback not found.");
            }

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
