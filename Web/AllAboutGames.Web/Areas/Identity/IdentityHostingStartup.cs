using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AllAboutGames.Web.Areas.Identity.IdentityHostingStartup))]

namespace AllAboutGames.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}