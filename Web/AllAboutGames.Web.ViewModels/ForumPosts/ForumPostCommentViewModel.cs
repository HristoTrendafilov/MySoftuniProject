namespace AllAboutGames.Web.ViewModels.ForumPosts
{
    using System.Globalization;

    using AllAboutGames.Common;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;
    using AutoMapper;

    public class ForumPostCommentViewModel : IMapFrom<ForumComment>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string FilterText => new Censor().CensorText(this.Text);

        public string UserId { get; set; }

        public string UserProfilePicture { get; set; }

        public int UserForumPostsCount { get; set; }

        public string UserCreatedOn { get; set; }

        public string CreatedOn { get; set; }

        public string UserUserName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ForumComment, ForumPostCommentViewModel>()
                .ForMember(x => x.UserCreatedOn, opt =>
                    opt.MapFrom(x => x.User.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(x => x.CreatedOn, opt =>
                    opt.MapFrom(x => x.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
