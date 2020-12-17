namespace AllAboutGames.Web.ViewModels.FeedBack
{
    using System;

    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;

    public class AllFeedBackViewModel : IMapFrom<FeedBack>
    {
        public string Id { get; set; }

        public string About { get; set; }

        public string UserId { get; set; }

        public string UserProfilePicture { get; set; }

        public string UserUserName { get; set; }

        public string Text { get; set; }

        public DateTime UserCreatedOn { get; set; }

        public string UserCreatedOnAsString => this.UserCreatedOn.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

        public DateTime CreatedOn { get; set; }

        public string CreatedOnAsString => this.CreatedOn.ToString("dd/MM/yyyy hh:mm", System.Globalization.CultureInfo.InvariantCulture);
    }
}
