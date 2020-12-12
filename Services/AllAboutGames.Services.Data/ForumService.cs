using AllAboutGames.Data.Common.Repositories;
using AllAboutGames.Data.Models;
using AllAboutGames.Services.Mapping;
using AllAboutGames.Web.ViewModels.InputModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutGames.Services.Data
{
    public class ForumService : IForumService
    {
        private readonly IDeletableEntityRepository<ForumCategory> categoryRepository;
        private readonly IDeletableEntityRepository<ForumPost> postRepository;

        public ForumService(
            IDeletableEntityRepository<ForumCategory> categoryRepository,
            IDeletableEntityRepository<ForumPost> postRepository
            )
        {
            this.categoryRepository = categoryRepository;
            this.postRepository = postRepository;
        }

        public async Task<string> AddForumPostAsync(AddForumPostInputModel model, string userId)
        {
            var post = new ForumPost
            {
                ForumCategoryId = model.ForumCategoryId,
                Content = model.Content,
                Title = model.Title,
                UserId = userId,
            };

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();
            return post.ForumCategoryId;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int? count = null)
        {
            IQueryable<ForumCategory> query = this.categoryRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return await query.To<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(string id, string orderBy = null)
        {
            IQueryable<ForumCategory> query = this.categoryRepository.All().Where(x => x.Id == id);

            if (orderBy == "Asc")
            {
                query.OrderBy(x => x.ForumPosts.OrderBy(x => x.CreatedOn));
            }
            else if (orderBy == "Desc")
            {
                query.OrderByDescending(x => x.ForumPosts.OrderByDescending(x => x.CreatedOn));
            }

            return await query.To<T>().FirstOrDefaultAsync();
        }

        public async Task<T> GetPostByIdAsync<T>(string id)
        {
            return await this.postRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
        }
    }
}
