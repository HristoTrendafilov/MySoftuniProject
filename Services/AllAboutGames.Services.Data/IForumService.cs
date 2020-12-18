namespace AllAboutGames.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AllAboutGames.Web.ViewModels.ForumCategories;
    using AllAboutGames.Web.ViewModels.InputModels;

    public interface IForumService
    {
        Task<IEnumerable<T>> GetAllCategoriesAsync<T>(int? count = null);

        Task<T> GetCategoryByIdAsync<T>(string id);

        Task<string> AddForumPostAsync(AddForumPostInputModel model, string userId);

        Task<T> GetPostByIdAsync<T>(string id);

        Task LikeAsync(string forumPostId, string userId);

        int GetLikes(string postId);

        Task AddCategoryAsync(AddForumCategoryInputModel model);

        Task DeleteCategoryAsync(string id);

        Task DeletePostAsync(string id);

        Task EditCategoryAsync(string id, AddForumCategoryInputModel model);

        Task EditPostAsync(string id, AddForumPostInputModel model);

        Task<AddForumPostInputModel> GetCurrentPost(string id);

        Task<IEnumerable<ForumPostInCategoryViewModel>> GetAllForumPostsByCategory(string id, int page, int itemsToShow);

        Task<int> GetCurrentCategoryPostsCount(string id);

        int GetTotalPostsCount();

        Task AddCommentAsync(string text, string postId, string userId);

        Task DeleteCommentAsync(string id);
    }
}
