namespace AllAboutGames.Web.ViewModels.ForumCategories
{
    using System.Globalization;

    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;
    using AutoMapper;

    public class ForumPostInCategoryViewModel : IMapFrom<ForumPost>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string UserId { get; set; }

        public string UserProfilePicture { get; set; }

        public string UserUserName { get; set; }

        public string Content { get; set; }

        public string ShortContent => this.Content?.Length > 700 ? this.Content?.Substring(0, 700) + "..." : this.Content;

        public int UserForumPostsCount { get; set; }

        public string UserCreatedOn { get; set; }

        public int ForumCommentsCount { get; set; }

        public int ForumLikesCount { get; set; }

        public string CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ForumPost, ForumPostInCategoryViewModel>()
                .ForMember(x => x.UserCreatedOn, opt =>
                    opt.MapFrom(x => x.User.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(x => x.CreatedOn, opt =>
                    opt.MapFrom(x => x.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
