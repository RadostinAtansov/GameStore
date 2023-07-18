using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class CommunityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
