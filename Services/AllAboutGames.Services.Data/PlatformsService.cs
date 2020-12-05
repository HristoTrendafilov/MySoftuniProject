namespace AllAboutGames.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Mapping;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Platforms;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    public class PlatformsService : IPlatformsService
    {
        private readonly IDeletableEntityRepository<Platform> platformRepository;
        private readonly IDeletableEntityRepository<Developer> developerRepository;
        private readonly IDeletableEntityRepository<Game> gameRepository;

        public PlatformsService(
            IDeletableEntityRepository<Platform> platformRepository,
            IDeletableEntityRepository<Developer> developerRepository,
            IDeletableEntityRepository<Game> gameRepository)
        {
            this.platformRepository = platformRepository;
            this.developerRepository = developerRepository;
            this.gameRepository = gameRepository;
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

            var imagePath = await this.UploadedFile(model.Image, model.Name, rootPath);

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

        private async Task<string> UploadedFile(IFormFile image, string platformName, string rootPath)
        {
            var fileName = Path.GetFileName(image.FileName);
            var directory = $"{rootPath}\\images\\platforms\\{platformName}";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{rootPath}\\images\\platforms\\{platformName}", fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileSteam);
            }

            return $"\\images\\platforms\\{platformName}\\{fileName}";
        }
    }
}
