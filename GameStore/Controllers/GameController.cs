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
        public async Task<IActionResult> ReturnAllGames()
        {
            var allGames = await _gameService.GetAllGames();
            return View(allGames);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllTopRatedGames()
        {
            var allGames = await _gameService.GetAllGamesTopRated();
            return View(allGames);
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllComingSoonGames()
        {
            var allGames = await _gameService.GetAllGamesComingSoon();
            return View(allGames);
        }

        [HttpGet]
        public async Task<IActionResult> RecentlyReleasedGames()
        {
            var allGames = await _gameService.RecentlyReleasedGames();
            return View(allGames);
        }

        [HttpGet]
        public async Task<IActionResult> MostAnticipatedGames()
        {
            var allGames = await _gameService.MostAnticipatedGames();
            return View(allGames);
        }

        [HttpGet]
        public async Task<IActionResult> SearchByName(string search)
        {
            var allGames = await _gameService.SearchByName(search);
            return View(allGames);
        }

        //[HttpGet("game-details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var game = await _gameService.GetDetails(id);

            return View(game);
        }
    }
}