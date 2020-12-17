using AllAboutGames.Web.ViewModels.FeedBack;
using AllAboutGames.Web.ViewModels.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllAboutGames.Services.Data
{
    public interface IFeedBackService
    {
        Task AddAsync(AddFeedBackInputModel model, string userId);

        IEnumerable<AllFeedBackViewModel> GetAll();

        Task DeleteFeedBackAsync(string id);
    }
}
