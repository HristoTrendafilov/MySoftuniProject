using AllAboutGames.Web.ViewModels.Home;
using System.Threading.Tasks;

namespace AllAboutGames.Services.Data
{
    public interface IIndexService
    {
        Task<IndexPageViewModel> GetDataAsync();
    }
}
