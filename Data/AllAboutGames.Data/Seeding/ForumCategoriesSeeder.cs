namespace AllAboutGames.Data.Seeding
{
    using AllAboutGames.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ForumCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ForumCategories.Any())
            {
                return;
            }

            string[] forumCategories = { "News", "Music", "Sport", "Gaming", "Coronavirus" };

            foreach (var category in forumCategories)
            {
                await dbContext.ForumCategories.AddAsync(new ForumCategory { Name = category, Description = category, Title = category, });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
