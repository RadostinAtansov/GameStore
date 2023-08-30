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

        [HttpGet]
        public async Task<IActionResult> ReturnAllPlatforms()
        {
            var allPlatforms = await _gameService.ReturnAllPlatform();
            return View(allPlatforms);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnPlatform(int id)
        {
            var platform = await _gameService.ReturnPlatformDetails(id);
            return View("DetailsPlatform", platform);
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