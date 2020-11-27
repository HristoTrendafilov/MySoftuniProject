namespace AllAboutGames.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class LanguagesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Languages.Any())
            {
                return;
            }

            string[] languages = { "English", "Brazilian", "Portuguese", "French", "Polish", "German", "Russian", "Japanese",
                "Korean", "Italian", "Turkish", "Arabic", };

            foreach (var language in languages)
            {
                await dbContext.Languages.AddAsync(new Language() { Name = language });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
