namespace GameStore.Controllers
{
    using GameStore.Data.Services.Interfaces;
    using GameStore.Models.GameViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(AddGameViewModel game)
        {
            if (!ModelState.IsValid)
            {
                return View(game);
            }
            await _gameService.AddGame(game);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllPlatforms()
        {
            var allGames = await _gameService.ReturnAllPlatform();
            return View(allGames);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllGames()
        {
            var allGames = await _gameService.GetAllGames();
            return View(allGames);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllTopRatedGames()
        {
            var allGames = await _gameService.GetAllGamesTopRated();
            return View("ReturnAllGames", allGames);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllComingSoonGames()
        {
            var allGames = await _gameService.GetAllGamesComingSoon();
            return View("ReturnAllGames", allGames);
        }

        [HttpGet]
        public async Task<IActionResult> RecentlyReleasedGames()
        {
            var allGames = await _gameService.RecentlyReleasedGames();
            return View("ReturnAllGames", allGames);
        }

        [HttpGet]
        public async Task<IActionResult> MostAnticipatedGames()
        {
            var allGames = await _gameService.MostAnticipatedGames();
            return View("ReturnAllGames", allGames);
        }

        [HttpGet]
        public async Task<IActionResult> SearchByName(string searchByName)
        {
            var allGames = await _gameService.SearchByName(searchByName);
            return View("ReturnAllGames", allGames);
        }

        [HttpGet]
        public async Task<IActionResult> SearchByPlatform(string platformSearch)
        {
            var allGames = await _gameService.SearchByPlatform(platformSearch);
            return View("ReturnAllGames", allGames);
        }

        [HttpGet]
        public async Task<IActionResult> SearchByGenre(string searchByGenre)
        {
            var allGames = await _gameService.SearchByGenre(searchByGenre);
            return View("ReturnAllGames", allGames);
        }

        //[HttpGet("game-details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var game = await _gameService.GetDetails(id);
            return View(game);
        }
    }
}