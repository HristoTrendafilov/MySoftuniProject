namespace AllAboutGames.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using AllAboutGames.Services.Data;
    using AllAboutGames.Services.Data.InputModels;
    using Microsoft.AspNetCore.Mvc;

    public class PlatformsController : Controller
    {
        private readonly IPlatformsService platformService;

        public PlatformsController(IPlatformsService platformService)
        {
            this.platformService = platformService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPlatformInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (this.platformService.CheckIfPlatformExists(model.Name))
                {
                    return this.Redirect("/Platforms/Add");
                }

                await this.platformService.AddPlatformAsync(model);
            }

            return this.Redirect("/Platforms/Add");
        }
    }
}
