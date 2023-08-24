namespace GameStore.Controllers
{
    using GameStore.Models.UserModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Area("Identity")]
    public class AccountController : Controller
    {
        //private readonly IAuthorizationUserService _authorizationUserService;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(/*IAuthorizationUserService authorizationUserService,*/
            SignInManager<IdentityUser> signInManager)
        {
            //_authorizationUserService = authorizationUserService;
            _signInManager = signInManager;
        }
      
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel register)
        {  
            return View();
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel requestUser)
        {
            return View();
        }
    }
}