namespace AllAboutGames.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using AllAboutGames.Web.ViewModels.FeedBack;
    using AllAboutGames.Web.ViewModels.InputModels;

    public interface IFeedBackService
    {
        Task AddAsync(AddFeedBackInputModel model, string userId);

        IEnumerable<AllFeedBackViewModel> GetAll();

        Task DeleteFeedBackAsync(string id);
    }
}
