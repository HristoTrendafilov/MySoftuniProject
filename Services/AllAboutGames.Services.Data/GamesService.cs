﻿namespace AllAboutGames.Services.Data
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Web.ViewModels.Game;
    using AllAboutGames.Web.ViewModels.Games;
    using AllAboutGames.Web.ViewModels.InputModels;
    using Microsoft.AspNetCore.Hosting;

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

        public AddGameViewModel GetAllInfo()
        {
            var viewModel = new AddGameViewModel()
            {
                Genres = this.genreRepository.All().OrderBy(x => x.Name).ToList(),
                Languages = this.languageRepository.All().OrderBy(x => x.Name).ToList(),
                Platforms = this.platformRepository.All().OrderBy(x => x.Name).ToList(),
            };

            return viewModel;
        }

        public async Task AddGameAsync(AddGameInputModel model)
        {
            var developer = this.developerRepository.All().FirstOrDefault(x => x.Name == model.Developer);

            if (developer == null)
            {
                developer = new Developer() { Name = model.Developer };
            }

            var imageName = await this.UploadedFile(model);

            var game = new Game()
            {
                Name = model.Name,
                Developer = developer,
                Image = imageName,
                Price = model.Price,
                ReleaseDate = model.ReleaseDate,
                TrailerUrl = model.Trailer,
                Summary = model.Summary,
                Website = model.Website,
            };

            foreach (var genre in model.Genres)
            {
                var currentGenre = this.genreRepository.All().FirstOrDefault(x => x.Name == genre);

                game.GamesGenres.Add(new GameGenre() { Game = game, Genre = currentGenre });
            }

            foreach (var language in model.Languages)
            {
                var currentLanguage = this.languageRepository.All().FirstOrDefault(x => x.Name == language);

                game.GamesLanguages.Add(new GameLanguage() { Game = game, Language = currentLanguage });
            }

            foreach (var platform in model.Platforms)
            {
                var currentPlatform = this.platformRepository.All().FirstOrDefault(x => x.Name == platform);

                game.GamesPlatforms.Add(new GamePlatform() { Game = game, Platform = currentPlatform });
            }

            await this.gameRepository.AddAsync(game);
            await this.gameRepository.SaveChangesAsync();
        }

        public void CheckIfGameNameExists(string name)
        {
            if (this.gameRepository.All().Any(x => x.Name == name))
            {
                return;
            }
        }

        public GameDetailsViewModel GetDetails(string id)
        {
            return this.gameRepository.All()
                .Where(x => x.Id == id)
                .Select(x => new GameDetailsViewModel
                {
                    Name = x.Name,
                    Developer = x.Developer.Name,
                    Image = x.Image,
                    Price = x.Price.ToString() + "$",
                    Rating = x.Rating,
                    TrailerUrl = x.TrailerUrl,
                    Website = x.Website,
                    Summary = x.Summary,
                    Genres = string.Join(", ", x.GamesGenres.Select(gg => gg.Genre.Name)),
                    Languages = string.Join(", ", x.GamesLanguages.Select(gl => gl.Language.Name)),
                    Platforms = string.Join(", ", x.GamesPlatforms.Select(gp => gp.Platform.Name)),
                    Comments = x.Comments.Select(c => new GameCommentsViewModel { Text = c.Text, User = c.User.UserName }),
                })
                .FirstOrDefault();
        }

        private async Task<string> UploadedFile(AddGameInputModel model)
        {
            var fileName = Path.GetFileName(model.Image.FileName);
            var directory = $"wwwroot\\images\\games\\{model.Name}";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\games\\{model.Name}", fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await model.Image.CopyToAsync(fileSteam);
            }

            return $"\\images\\games\\{model.Name}\\{fileName}";
        }
    }
}
