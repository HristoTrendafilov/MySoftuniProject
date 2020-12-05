namespace AllAboutGames.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IIndexService indexService;

        public HomeController(IIndexService indexService)
        {
            this.indexService = indexService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await this.indexService.GetDataAsync();
            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
