﻿namespace AllAboutGames.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : Controller
    {
        public IActionResult All()
        {
            return this.View();
        }
    }
}
