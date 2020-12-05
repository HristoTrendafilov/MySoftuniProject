namespace AllAboutGames.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AllAboutGames.Data;
    using AllAboutGames.Data.Common.Models;
    using AllAboutGames.Data.Common.Repositories;
    using AllAboutGames.Data.Models;
    using AllAboutGames.Services.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    [Area("Administration")]
    public class GamesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Game> gameRepository;
        private readonly IDeletableEntityRepository<Developer> developerRepository;

        public GamesController(
            IDeletableEntityRepository<Game> gameRepository,
            IDeletableEntityRepository<Developer> developerRepository)
        {
            this.gameRepository = gameRepository;
            this.developerRepository = developerRepository;
        }

        // GET: Administration/Games
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.gameRepository.All().Include(g => g.Developer);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Games/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var game = await this.gameRepository.All()
                .Include(g => g.Developer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return this.NotFound();
            }

            return this.View(game);
        }

        // GET: Administration/Games/Create
        public IActionResult Create()
        {
            this.ViewData["DeveloperId"] = new SelectList(this.developerRepository.All(), "Id", "Id");
            return this.View();
        }

        // POST: Administration/Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Summary,Image,Website,ReleaseDate,RatingsCount,TrailerUrl,DeveloperId,IsDeleted,DeletedOn")] Game game)
        {
            if (this.ModelState.IsValid)
            {
                await this.gameRepository.AddAsync(game);
                await this.gameRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["DeveloperId"] = new SelectList(this.developerRepository.All(), "Id", "Id", game.DeveloperId);
            return this.View(game);
        }

        // GET: Administration/Games/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var game = await this.gameRepository.All().Include(x => x.Developer).FirstOrDefaultAsync(x => x.Id == id);
            if (game == null)
            {
                return this.NotFound();
            }

            this.ViewData["DeveloperId"] = new SelectList(this.developerRepository.All(), "Id", "Id", game.DeveloperId);
            return this.View(game);
        }

        // POST: Administration/Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Price,Summary,Image,Website,ReleaseDate,RatingsCount,TrailerUrl,DeveloperId,IsDeleted,DeletedOn")] Game game)
        {
            if (id != game.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.gameRepository.Update(game);
                    await this.gameRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.GameExists(game.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["DeveloperId"] = new SelectList(this.developerRepository.All(), "Id", "Id", game.DeveloperId);
            return this.View(game);
        }

        // GET: Administration/Games/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var game = await this.gameRepository.All()
                .Include(g => g.Developer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return this.NotFound();
            }

            return this.View(game);
        }

        // POST: Administration/Games/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var game = await this.gameRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            this.gameRepository.Delete(game);
            await this.gameRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool GameExists(string id)
        {
            return this.gameRepository.All().Any(e => e.Id == id);
        }
    }
}
