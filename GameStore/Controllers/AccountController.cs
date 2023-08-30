namespace GameStore.Controllers
{
    using GameStore.Data;
    using GameStore.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using GameStore.Data.Services.Interfaces;

    public class AccountController : Controller
    {
        private readonly GameStoreDataDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAccountService _accountService;

        public AccountController(
               GameStoreDataDbContext dbContext, 
               UserManager<IdentityUser> userManager, 
               SignInManager<IdentityUser> signInManager,
               IAccountService accountService)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
        }

        public async Task<IActionResult> AddToWishList(int gameId)
        {
            var userNameEmail = User.Identity.Name;
            
            var userIdFromDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userNameEmail);

            string userIdFromDbToGameUsers = userIdFromDb.Id;

            UserGames_GamesUser ug = new UserGames_GamesUser()
            {
                UserId = userIdFromDbToGameUsers,
                Game = new Game() { GameIdFromIGDB = gameId }
            };

            await _dbContext.UserGames_GamesUsers.AddAsync(ug);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RemoveGameFromWish(int id)
        {
            var userNameEmail = User.Identity.Name;

            await _accountService.RemoveGame(id, userNameEmail);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ShowWishList()
        {
            var userNameEmail = User.Identity.Name;
            var wishlist = await _accountService.ShowWishList(userNameEmail);
            return View(wishlist);
        }
    }
}