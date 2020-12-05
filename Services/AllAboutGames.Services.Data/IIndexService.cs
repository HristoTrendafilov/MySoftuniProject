namespace AllAboutGames.Services.Data
{
    using System.Threading.Tasks;

    using AllAboutGames.Web.ViewModels.Home;

    public interface IIndexService
    {
        Task<IndexPageViewModel> GetDataAsync();
    }
}
