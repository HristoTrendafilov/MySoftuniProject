namespace AllAboutGames.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using AllAboutGames.Common;
    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Platforms;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    public class PlatformsService : IPlatformsService
    {
        private const string MainFilePath = "platforms";

        private readonly IDeletableEntityRepository<Platform> platformRepository;
        private readonly IDeletableEntityRepository<Developer> developerRepository;
        private readonly IDeletableEntityRepository<Game> gameRepository;
        private readonly IGamesService gamesService;

        public PlatformsService(
            IDeletableEntityRepository<Platform> platformRepository,
            IDeletableEntityRepository<Developer> developerRepository,
            IDeletableEntityRepository<Game> gameRepository,
            IGamesService gamesService)
        {
            this.platformRepository = platformRepository;
            this.developerRepository = developerRepository;
            this.gameRepository = gameRepository;
            this.gamesService = gamesService;
        }

        public async Task AddPlatformAsync(AddPlatformInputModel model, string rootPath)
        {
            var developer = await this.developerRepository.All().FirstOrDefaultAsync(x => x.Name == model.Developer);

            if (developer == null)
            {
                developer = new Developer()
                {
                    Name = model.Developer,
                };
            }

            var imagePath = await GlobalMethods.UploadedFile(model.Image, model.Name, rootPath, MainFilePath);

            var platform = new Platform()
            {
                Info = model.Info,
                ReleaseDate = model.ReleaseDate,
                Developer = developer,
                Image = imagePath,
                Name = model.Name,
            };

            await this.platformRepository.AddAsync(platform);
            await this.platformRepository.SaveChangesAsync();
        }

        public async Task CheckIfPlatformExistsByNameAsync(string name)
        {
            var platform = await this.platformRepository.All().FirstOrDefaultAsync(x => x.Name == name);

            if (platform == null)
            {
                throw new ArgumentException("Platform already exists.");
            }
        }

        public async Task<IEnumerable<AllGamesByPlatformViewModel>> GetAllGamesByPlatformAsync(string platform, int page, int itemsToShow = 8)
        {
            return await this.gameRepository.AllAsNoTracking()
                .Where(x => x.GamePlatforms.Any(gp => gp.Platform.Name.Contains(platform)))
                .OrderByDescending(x => x.ReleaseDate)
                .Skip((page - 1) * itemsToShow)
                .Take(itemsToShow)
                .To<AllGamesByPlatformViewModel>()
                .ToListAsync();
        }

        public int GetGamesCount(string platform)
        {
            return this.gameRepository.AllAsNoTracking()
                .Where(x => x.GamePlatforms.Any(gp => gp.Platform.Name.Contains(platform)))
                .Count();
        }
    }
}
