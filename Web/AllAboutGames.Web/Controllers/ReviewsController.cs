using Microsoft.AspNetCore.Mvc;

namespace AllAboutGames.Web.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult All()
        {
            return this.View();
        }
    }
}
