using AllAboutGames.Web.ViewModels.InputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllAboutGames.Services.Data
{
    public interface IForumService
    {
        Task<IEnumerable<T>> GetAllAsync<T>(int? count = null);

        Task<T> GetByIdAsync<T>(string id, string orderBy = null);

        Task<string> AddForumPostAsync(AddForumPostInputModel model, string userId);

        Task<T> GetPostByIdAsync<T>(string id);
    }
}
