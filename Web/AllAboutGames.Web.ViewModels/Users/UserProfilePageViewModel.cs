namespace AllAboutGames.Web.ViewModels.Users
{

    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class UserProfilePageViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string DateOfBirth { get; set; }

        public string CreatedOn { get; set; }

        public string CityName { get; set; }

        public string CountryName { get; set; }

        public int ReviewsCount { get; set; }

        public int GameCommentsCount { get; set; }

        public string ProfilePicture { get; set; }

        public int ForumPostsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserProfilePageViewModel>()
                .ForMember(x => x.DateOfBirth, opt =>
                    opt.MapFrom(x => x.DateOfBirth.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(x => x.CountryName, opt =>
                    opt.MapFrom(x => x.City.Country.Name))
                .ForMember(x => x.CreatedOn, opt =>
                    opt.MapFrom(x => x.CreatedOn.ToString("dd/MM/yyy", CultureInfo.InvariantCulture)));
        }
    }
}
