namespace AllAboutGames.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class GenresSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Genres.Any())
            {
                return;
            }

            string[] genres =
                { "Indie", "Action", "Adventure", "Casual", "Simulation", "Strategy", "RPG",
                "Singleplayer", "Violent", "Sports", "Racing", "Multiplayer", "Puzzle", "Fantasy",
                "First-Person", "Horror", "Sci-fi", "Shooter", "Retro", "Co-Op", "Exploration", "Open world", "Third person",
                "PVP", "Space", "Fighting", "Aliens",
                };

            foreach (var genre in genres)
            {
                await dbContext.Genres.AddAsync(new Genre() { Name = genre });
            }
        }
    }
}
