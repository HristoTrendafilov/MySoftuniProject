namespace AllAboutGames.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Data.InputModels;
    using Microsoft.EntityFrameworkCore;

    public class PlatformsService : IPlatformsService
    {
        private readonly IDeletableEntityRepository<Platform> platformRepository;
        private readonly IDeletableEntityRepository<Developer> developerRepository;

        public PlatformsService(
            IDeletableEntityRepository<Platform> platformRepository,
            IDeletableEntityRepository<Developer> developerRepository)
        {
            this.platformRepository = platformRepository;
            this.developerRepository = developerRepository;
        }

        public async Task<Platform> AddPlatformAsync(AddPlatformInputModel model)
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

            return platform;
        }

        public bool CheckIfPlatformExists(string name)
        {
            return this.platformRepository.All().Any(x => x.Name == name);
        }
    }
}
