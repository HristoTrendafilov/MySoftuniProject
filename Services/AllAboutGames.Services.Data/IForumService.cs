using AllAboutGames.Web.ViewModels.ForumPosts;
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

        Task LikeAsync(string forumPostId, string userId);

        int GetLikes(string postId);

        Task AddCategoryAsync(AddForumCategoryInputModel model);

        Task DeleteCategoryAsync(string id);

        Task DeletePostAsync(string id);

        Task EditCategoryAsync(string id, AddForumCategoryInputModel model);

        Task EditPostAsync(string id, AddForumPostInputModel model);

        Task<EditPostViewModel> GetCurrentPost(string id);
    }
}
