namespace GameStore.Controllers
{
    using GameStore.Models;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using GameStore.Data.Services.Interfaces;
    using Microsoft.AspNetCore.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            ViewData["ErrorMessage"] = $"Error occurred. The ErrorCode is: {code}";
            return View("~/Views/Shared/HandleError.cshtml");
        }

        [HttpGet]
        public async Task<IActionResult> RenderGamesMiddle()
        {
            var games = await _homeService.ReturnMiddleSiteOnPageGamesFromIGDB();
            return PartialView("_RecentlyReleasedPartial", games);
        }

        [HttpGet]
        public async Task<IActionResult> RenderMostAnticipatedGames()
        {
            var games = await _homeService.ReturnMostAnticipatedGamesFromIGDB();
            return PartialView("_ReturnMostAnticipatedGamesPartialView", games);
        }

        [HttpGet]
        public async Task<IActionResult> RenderGamesDownRecentlyReleased()
        {
            var games = await _homeService.ReturnRecentlyReleasedGamesFromIGDB();
            return PartialView("_RecentlyReleasedColumnPartial", games);
        }

        [HttpGet]
        public async Task<IActionResult> RenderGamesDownComingSoon()
        {
            var games = await _homeService.ReturnComingSoonGamesFromIGDB();
            return PartialView("_ComingSoonGamesColumnPartial", games);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var games = await _homeService.ReturnInfoFromIGDB();
            return View(games);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}