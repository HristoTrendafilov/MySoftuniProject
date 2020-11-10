namespace AllAboutGames.Web.Areas.Administration.Controllers
{
    using AllAboutGames.Common;
    using AllAboutGames.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
