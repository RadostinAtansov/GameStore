﻿namespace GameStore.Controllers
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
            return RedirectToAction("Home");
        }

        [HttpGet]
        public async Task<IActionResult> ReturnAllGames()
        {
            var allGames = await _gameService.GetAllGames();
            return View(allGames);
        }
    }
}