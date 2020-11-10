namespace AllAboutGames.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Data.InputModels;
    using AllAboutGames.Web.ViewModels.Game;

    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gameRepository;
        private readonly IDeletableEntityRepository<Platform> platformRepository;
        private readonly IDeletableEntityRepository<Genre> genreRepository;
        private readonly IDeletableEntityRepository<Language> languageRepository;
        private readonly IDeletableEntityRepository<Developer> developerRepository;

        public GamesService(
            IDeletableEntityRepository<Game> gameRepository,
            IDeletableEntityRepository<Platform> platformRepository,
            IDeletableEntityRepository<Genre> genreRepository,
            IDeletableEntityRepository<Language> languageRepository,
            IDeletableEntityRepository<Developer> developerRepository)
        {
            this.gameRepository = gameRepository;
            this.platformRepository = platformRepository;
            this.genreRepository = genreRepository;
            this.languageRepository = languageRepository;
            this.developerRepository = developerRepository;
        }

        public CreateGameViewModel GetAllInfo()
        {
            var viewModel = new CreateGameViewModel()
            {
                Genres = this.genreRepository.All().OrderBy(x => x.Name),
                Languages = this.languageRepository.All().OrderBy(x => x.Name),
                Platforms = this.platformRepository.All().OrderBy(x => x.Name),
            };

            return viewModel;
        }

        public async Task AddGameAsync(AddGameInputModel model)
        {
            CheckIfGameNameExists(model.Name);

            var developer = this.developerRepository.All().FirstOrDefault(x => x.Name == model.Developer);

            if (developer == null)
            {
                developer = new Developer() { Name = model.Developer };
            }

            var game = new Game()
            {
                Name = model.Name,
                Developer = developer,
                Image = model.Image,
                Price = model.Price,
                ReleaseDate = model.ReleaseDate,
                Summary = model.Summary,
                Website = model.Website,
            };

            foreach (var genre in model.Genre)
            {
                var currentGenre = this.genreRepository.All().FirstOrDefault(x => x.Name == genre);

                game.GamesGenres.Add(new GameGenre() { Game = game, Genre = currentGenre });
            }

            foreach (var language in model.Language)
            {
                var currentLanguage = this.languageRepository.All().FirstOrDefault(x => x.Name == language);

                game.GamesLanguages.Add(new GameLanguage() { Game = game, Language = currentLanguage });
            }

            foreach (var platform in model.Platform)
            {
                var currentPlatform = this.platformRepository.All().FirstOrDefault(x => x.Name == platform);

                game.GamesPlatforms.Add(new GamePlatform() { Game = game, Platform = currentPlatform });
            }

            await this.gameRepository.AddAsync(game);
            await this.gameRepository.SaveChangesAsync();
        }

        private void CheckIfGameNameExists(string name)
        {
            if (this.gameRepository.All().Any(x => x.Name == name))
            {
                return;
            }
        }
    }
}
