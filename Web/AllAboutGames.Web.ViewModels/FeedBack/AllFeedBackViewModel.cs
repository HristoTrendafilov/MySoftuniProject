namespace AllAboutGames.Web.ViewModels.FeedBack
{
    using System.Globalization;

    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;
    using AutoMapper;

    public class AllFeedBackViewModel : IMapFrom<FeedBack>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string About { get; set; }

        public string UserId { get; set; }

        public string UserProfilePicture { get; set; }

        public string UserUserName { get; set; }

        public string Text { get; set; }

        public string UserCreatedOn { get; set; }

        public string CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<FeedBack, AllFeedBackViewModel>()
                .ForMember(x => x.UserCreatedOn, opt =>
                    opt.MapFrom(x => x.User.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(x => x.CreatedOn, opt =>
                    opt.MapFrom(x => x.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));
        }
    }
}
