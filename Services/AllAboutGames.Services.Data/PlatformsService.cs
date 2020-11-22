namespace AllAboutGames.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Web.ViewModels.InputModels;
    using AllAboutGames.Web.ViewModels.Platforms;
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

        public async Task AddPlatformAsync(AddPlatformInputModel model)
        {
            var developer = await this.developerRepository.All().FirstOrDefaultAsync(x => x.Name == model.Developer);

            if (developer == null)
            {
                developer = new Developer()
                {
                    Name = model.Developer,
                };
            }

            var platform = new Platform()
            {
                Info = model.Info,
                ReleaseDate = model.ReleaseDate,
                Developer = developer,
                Image = model.Image,
                Name = model.Name,
            };

            await this.platformRepository.AddAsync(platform);
            await this.platformRepository.SaveChangesAsync();
        }

        public bool CheckIfPlatformExists(string name)
        {
            return this.platformRepository.All().Any(x => x.Name == name);
        }

        public IEnumerable<AllGamesByPlatformViewModel> GetAllGamesByPlatform(string platform)
        {
            return this.gameRepository.All()
                .Where(x => x.GamesPlatforms.Any(gp => gp.Platform.Name.Contains(platform)))
                .Select(x => new AllGamesByPlatformViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                })
                .ToList();
        }
    }
}
