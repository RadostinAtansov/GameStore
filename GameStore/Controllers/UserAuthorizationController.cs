using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class UserAuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
