namespace AllAboutGames.Services.Data
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Web.ViewModels.Game;
    using AllAboutGames.Web.ViewModels.Games;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    public class GamesService : IGamesService
    {
        private readonly IDeletableEntityRepository<Game> gameRepository;
        private readonly IDeletableEntityRepository<Platform> platformRepository;
        private readonly IDeletableEntityRepository<Genre> genreRepository;
        private readonly IDeletableEntityRepository<Language> languageRepository;
        private readonly IDeletableEntityRepository<Developer> developerRepository;
        private readonly IDeletableEntityRepository<GameGenre> gameGenreRepository;
        private readonly IDeletableEntityRepository<GameLanguage> gameLanguageRepository;
        private readonly IDeletableEntityRepository<GamePlatform> gamePlatformRepository;
        private readonly IRatingsService ratingsService;

        public GamesService(
            IDeletableEntityRepository<Game> gameRepository,
            IDeletableEntityRepository<Platform> platformRepository,
            IDeletableEntityRepository<Genre> genreRepository,
            IDeletableEntityRepository<Language> languageRepository,
            IDeletableEntityRepository<Developer> developerRepository,
            IDeletableEntityRepository<GameGenre> gameGenreRepository,
            IDeletableEntityRepository<GameLanguage> gameLanguageRepository,
            IDeletableEntityRepository<GamePlatform> gamePlatformRepository,
            IRatingsService ratingsService)
        {
            this.gameRepository = gameRepository;
            this.platformRepository = platformRepository;
            this.genreRepository = genreRepository;
            this.languageRepository = languageRepository;
            this.developerRepository = developerRepository;
            this.gameGenreRepository = gameGenreRepository;
            this.gameLanguageRepository = gameLanguageRepository;
            this.gamePlatformRepository = gamePlatformRepository;
            this.ratingsService = ratingsService;
        }

        public async Task<AddGameViewModel> GetAllInfoAsync()
        {
            var viewModel = new AddGameViewModel
            {
                Genres = await this.genreRepository.All().OrderBy(x => x.Name).ToListAsync(),
                Languages = await this.languageRepository.All().OrderBy(x => x.Name).ToListAsync(),
                Platforms = await this.platformRepository.All().OrderBy(x => x.Name).ToListAsync(),
            };

            return viewModel;
        }

        public async Task<EditGameViewModel> GetEditModel(string id)
        {
            return await this.gameRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new EditGameViewModel
                {
                    Developer = x.Developer.Name,
                    Name = x.Name,
                    Price = x.Price,
                    ReleaseDate = x.ReleaseDate,
                    Summary = x.Summary,
                    Trailer = x.TrailerUrl,
                    Website = x.Website,
                    GameGenres = this.genreRepository.All().Where(x => x.GamesGenres.Any(gg => gg.GameId == id)).ToList(),
                    GameLanguages = this.languageRepository.All().Where(x => x.GamesLanguages.Any(gg => gg.GameId == id)).ToList(),
                    GamePlatforms = this.platformRepository.All().Where(x => x.GamesPlatforms.Any(gg => gg.GameId == id)).ToList(),
                    Genres = this.genreRepository.All().ToList(),
                    Languages = this.languageRepository.All().ToList(),
                    Platforms = this.platformRepository.All().ToList(),
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddGameAsync(AddGameInputModel model, string rootPath)
        {
            var checkGame = await this.gameRepository.All().FirstOrDefaultAsync(x => x.Name == model.Name);

            if (checkGame != null)
            {
                throw new ArgumentException("Game already exists.");
            }

            var developer = await this.developerRepository.All().FirstOrDefaultAsync(x => x.Name == model.Developer);

            if (developer == null)
            {
                developer = new Developer() { Name = model.Developer };
            }

            var imagePath = await this.UploadedFile(model.Image, model.Name, rootPath);

            var game = new Game()
            {
                Name = model.Name,
                Developer = developer,
                Image = imagePath,
                Price = model.Price,
                ReleaseDate = model.ReleaseDate,
                TrailerUrl = model.Trailer,
                Summary = model.Summary,
                Website = model.Website,
            };

            foreach (var genreId in model.Genres)
            {
                var gameGenre = new GameGenre() { GameId = game.Id, GenreId = genreId };

                await this.gameGenreRepository.AddAsync(gameGenre);
                game.GameGenres.Add(gameGenre);
            }

            foreach (var languageId in model.Languages)
            {
                var gameLanguage = new GameLanguage() { GameId = game.Id, LanguageId = languageId };

                await this.gameLanguageRepository.AddAsync(gameLanguage);
                game.GameLanguages.Add(gameLanguage);
            }

            foreach (var platformId in model.Platforms)
            {
                var gamePlatform = new GamePlatform() { GameId = game.Id, PlatformId = platformId };

                await this.gamePlatformRepository.AddAsync(gamePlatform);
                game.GamePlatforms.Add(gamePlatform);
            }

            await this.gameRepository.AddAsync(game);
            await this.gameRepository.SaveChangesAsync();
            await this.gameGenreRepository.SaveChangesAsync();
            await this.gameLanguageRepository.SaveChangesAsync();
            await this.gamePlatformRepository.SaveChangesAsync();
        }

        public async Task<GameDetailsViewModel> GetDetailsAsync(string id)
        {
            await this.CheckIfGameExistsByIdAsync(id);

            var game = await this.gameRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new GameDetailsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    RatingsCount = x.RatingsCount,
                    Developer = x.Developer.Name,
                    Image = x.Image,
                    Price = x.Price == 0 ? "Free" : x.Price.ToString() + "$",
                    TrailerUrl = x.TrailerUrl != null ? x.TrailerUrl.Replace("watch?v=", "embed/") : null,
                    Website = x.Website ?? "No website available.",
                    Summary = x.Summary,
                    ReleaseDate = x.ReleaseDate.ToString("dd/MM/yyyy"),
                    Genres = string.Join(", ", x.GameGenres.Select(gg => gg.Genre.Name)),
                    Languages = string.Join(", ", x.GameLanguages.Select(gl => gl.Language.Name)),
                    Platforms = string.Join(", ", x.GamePlatforms.Select(gp => gp.Platform.Name)),
                    Comments = x.Comments.Select(c => new GameCommentsViewModel { Text = c.Text, User = c.User.UserName }),
                })
                .FirstOrDefaultAsync();

            if (game.RatingsCount > 0)
            {
                game.AverageRating = this.ratingsService.GetAverageRating(game.Id);
            }
            else
            {
                game.AverageRating = 0;
            }

            return game;
        }

        public async Task EditGameAsync(string id, EditGameInputModel model, string rootPath)
        {
            await this.CheckIfGameExistsByIdAsync(id);

            var game = await this.gameRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            var imagePath = await this.UploadedFile(model.Image, model.Name, rootPath);

            var developer = await this.developerRepository.All().FirstOrDefaultAsync(x => x.Name == model.Developer);

            if (developer == null)
            {
                developer = new Developer() { Name = model.Developer };
            }

            game.Name = model.Name;
            game.Image = imagePath;
            game.Price = model.Price;
            game.ReleaseDate = model.ReleaseDate;
            game.Summary = model.Summary;
            game.Website = model.Website;
            game.TrailerUrl = model.Trailer;
            game.Developer = developer;

            await this.gameRepository.SaveChangesAsync();

            var gameGenres = await this.gameGenreRepository.All().Where(x => x.GameId == game.Id).ToListAsync();
            var gameLanguages = await this.gameLanguageRepository.All().Where(x => x.GameId == game.Id).ToListAsync();
            var gamePlatforms = await this.gamePlatformRepository.All().Where(x => x.GameId == game.Id).ToListAsync();

            if (gameGenres.Count != 0)
            {
                foreach (var genre in gameGenres)
                {
                    this.gameGenreRepository.HardDelete(genre);
                    await this.gameGenreRepository.SaveChangesAsync();
                }
            }

            await this.UpdateGameGenres(model, game);

            if (gameLanguages.Count != 0)
            {
                foreach (var language in gameLanguages)
                {
                    this.gameLanguageRepository.HardDelete(language);
                    await this.gameLanguageRepository.SaveChangesAsync();
                }
            }

            await this.UpdateGameLanguages(model, game);

            if (gamePlatforms.Count != 0)
            {
                foreach (var platform in gamePlatforms)
                {
                    this.gamePlatformRepository.HardDelete(platform);
                    await this.gamePlatformRepository.SaveChangesAsync();
                }
            }

            await this.UpdateGamePlatforms(model, game);
        }

        public async Task DeleteGameAsync(string id)
        {
            await this.CheckIfGameExistsByIdAsync(id);

            var game = await this.gameRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            if (game == null)
            {
                throw new NullReferenceException("Game not found");
            }

            game.IsDeleted = true;
            game.DeletedOn = DateTime.UtcNow;
            this.gameRepository.Update(game);
            await this.gameRepository.SaveChangesAsync();

            var gameGenres = await this.gameGenreRepository
                .All()
                .Where(x => x.GameId == id)
                .ToListAsync();

            var gameLanguages = await this.gameLanguageRepository
                .All()
                .Where(x => x.GameId == id)
                .ToListAsync();

            var gamePlatforms = await this.gamePlatformRepository
                .All()
                .Where(x => x.GameId == id)
                .ToListAsync();

            foreach (var gameGenre in gameGenres)
            {
                gameGenre.IsDeleted = true;
                gameGenre.DeletedOn = DateTime.UtcNow;
                this.gameGenreRepository.Update(gameGenre);
            }

            foreach (var gamelanguage in gameLanguages)
            {
                gamelanguage.IsDeleted = true;
                gamelanguage.DeletedOn = DateTime.UtcNow;
                this.gameLanguageRepository.Update(gamelanguage);
            }

            foreach (var gamePlatform in gamePlatforms)
            {
                gamePlatform.IsDeleted = true;
                gamePlatform.DeletedOn = DateTime.UtcNow;
                this.gamePlatformRepository.Update(gamePlatform);
            }

            await this.gameGenreRepository.SaveChangesAsync();
            await this.gameLanguageRepository.SaveChangesAsync();
            await this.gamePlatformRepository.SaveChangesAsync();
        }

        public async Task CheckIfGameExistsByIdAsync(string id)
        {
            var game = await this.gameRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            if (game == null)
            {
                throw new ArgumentException("Game not found.");
            }
        }

        private async Task UpdateGameGenres(EditGameInputModel model, Game game)
        {
            foreach (var genreId in model.Genres)
            {
                var gameGenre = new GameGenre { GameId = game.Id, GenreId = genreId };

                await this.gameGenreRepository.AddAsync(gameGenre);
                game.GameGenres.Add(gameGenre);
            }

            await this.gameGenreRepository.SaveChangesAsync();
            await this.gameRepository.SaveChangesAsync();
        }

        private async Task UpdateGameLanguages(EditGameInputModel model, Game game)
        {
            foreach (var languageId in model.Languages)
            {
                var gameLanguage = new GameLanguage { GameId = game.Id, LanguageId = languageId };

                await this.gameLanguageRepository.AddAsync(gameLanguage);
                game.GameLanguages.Add(gameLanguage);
            }

            await this.gameLanguageRepository.SaveChangesAsync();
            await this.gameRepository.SaveChangesAsync();
        }

        private async Task UpdateGamePlatforms(EditGameInputModel model, Game game)
        {
            foreach (var platformId in model.Platforms)
            {
                var gamePlatform = new GamePlatform { GameId = game.Id, PlatformId = platformId };

                await this.gamePlatformRepository.AddAsync(gamePlatform);
                game.GamePlatforms.Add(gamePlatform);
            }

            await this.gamePlatformRepository.SaveChangesAsync();
            await this.gameRepository.SaveChangesAsync();
        }

        private async Task<string> UploadedFile(IFormFile image, string gameName, string rootPath)
        {
            var fileName = Path.GetFileName(image.FileName);
            var directory = $"{rootPath}\\images\\games\\{gameName}";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{rootPath}\\images\\games\\{gameName}", fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileSteam);
            }

            return $"\\images\\games\\{gameName}\\{fileName}";
        }
    }
}
