using AllAboutGames.Data.Common.Repositories;
using AllAboutGames.Data.Models;
using AllAboutGames.Services.Mapping;
using AllAboutGames.Web.ViewModels.ForumCategories;
using AllAboutGames.Web.ViewModels.ForumPosts;
using AllAboutGames.Web.ViewModels.InputModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutGames.Services.Data
{
    public class ForumService : IForumService
    {
        private readonly IDeletableEntityRepository<ForumCategory> categoryRepository;
        private readonly IDeletableEntityRepository<ForumPost> postRepository;
        private readonly IDeletableEntityRepository<ForumComment> commentsRepository;
        private readonly IRepository<ForumLike> likeRepository;

        public ForumService(
            IDeletableEntityRepository<ForumCategory> categoryRepository,
            IDeletableEntityRepository<ForumPost> postRepository,
            IDeletableEntityRepository<ForumComment> commentsRepository,
            IRepository<ForumLike> likeRepository)
        {
            this.categoryRepository = categoryRepository;
            this.postRepository = postRepository;
            this.commentsRepository = commentsRepository;
            this.likeRepository = likeRepository;
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

        public async Task<T> GetByIdAsync<T>(string id)
        {
            return await this.categoryRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefaultAsync();
        }

        public async Task<T> GetPostByIdAsync<T>(string id)
        {
            return await this.postRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
        }

        public int GetLikes(string postId)
        {
            return this.likeRepository.All().Where(x => x.ForumPostId == postId).Count();
        }

        public async Task LikeAsync(string forumPostId, string userId)
        {
            var like = await this.likeRepository.All().FirstOrDefaultAsync(x => x.ForumPostId == forumPostId && x.UserId == userId);

            if (like == null)
            {
                like = new ForumLike
                {
                    ForumPostId = forumPostId,
                    UserId = userId,
                };
                await this.likeRepository.AddAsync(like);
            }

            await this.likeRepository.SaveChangesAsync();
        }

        public async Task AddCategoryAsync(AddForumCategoryInputModel model)
        {
            var category = new ForumCategory
            {
                Name = model.Name,
                Description = model.Description,
                Image = model.Image,
            };

            await this.categoryRepository.AddAsync(category);
            await this.categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(string id)
        {
            var category = await this.categoryRepository.All().Include(x => x.ForumPosts).FirstOrDefaultAsync(x => x.Id == id);

            category.IsDeleted = true;
            category.DeletedOn = DateTime.UtcNow;
            this.categoryRepository.Update(category);
            await this.categoryRepository.SaveChangesAsync();

            var posts = category.ForumPosts;

            foreach (var post in posts)
            {
                foreach (var comment in post.ForumComments)
                {
                    comment.IsDeleted = true;
                    comment.DeletedOn = DateTime.UtcNow;
                    this.commentsRepository.Update(comment);
                }

                post.IsDeleted = true;
                post.DeletedOn = DateTime.UtcNow;
                this.postRepository.Update(post);
            }

            await this.commentsRepository.SaveChangesAsync();
            await this.postRepository.SaveChangesAsync();
        }

        public async Task DeletePostAsync(string id)
        {
            var post = await this.postRepository.All()
                .Include(x => x.ForumComments)
                .FirstOrDefaultAsync(x => x.Id == id);

            post.IsDeleted = true;
            post.DeletedOn = DateTime.UtcNow;
            this.postRepository.Update(post);
            await this.postRepository.SaveChangesAsync();

            var comments = post.ForumComments;

            foreach (var comment in comments)
            {
                comment.IsDeleted = true;
                comment.DeletedOn = DateTime.UtcNow;
                this.commentsRepository.Update(comment);
            }

            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task EditCategoryAsync(string id, AddForumCategoryInputModel model)
        {
            var category = await this.categoryRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            category.Name = model.Name;
            category.Description = model.Description;
            category.Image = model.Image;

            await this.categoryRepository.SaveChangesAsync();
        }

        public async Task EditPostAsync(string id, AddForumPostInputModel model)
        {
            var post = await this.postRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            post.Title = model.Title;
            post.Content = model.Content;
            post.ForumCategoryId = model.ForumCategoryId;

            await this.postRepository.SaveChangesAsync();
        }

        public async Task<EditPostViewModel> GetCurrentPost(string id)
        {
            return await this.postRepository.All().Where(x => x.Id == id).Select(x => new EditPostViewModel
            {
                Content = x.Content,
                Title = x.Title,
            })
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ForumPostInCategoryViewModel>> GetAllForumPostsByCategory(string id, int page, int itemsToShow)
        {
            var posts = await this.postRepository.AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.ForumCategoryId == id)
                .Skip((page - 1) * itemsToShow)
                .Take(itemsToShow)
                .To<ForumPostInCategoryViewModel>()
                .ToListAsync();

            return posts;
        }

        public async Task<int> GetCurrentCategoryPostsCount(string id)
        {
            var category = await this.categoryRepository.All().Include(x => x.ForumPosts).FirstOrDefaultAsync(x => x.Id == id);

            return category.ForumPosts.Count();
        }

        public int GetTotalPostsCount()
        {
            return this.postRepository.All().Count();
        }

        public async Task AddCommentAsync(string text, string postId, string userId)
        {
            var comment = new ForumComment
            {
                Text = text,
                ForumPostId = postId,
                UserId = userId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(string id)
        {
            var comment = await this.commentsRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            comment.IsDeleted = true;
            comment.DeletedOn = DateTime.UtcNow;
            this.commentsRepository.Update(comment);
            await this.commentsRepository.SaveChangesAsync();
        }
    }
}
