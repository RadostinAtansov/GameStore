using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you request could not be found 404";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Sorry, the resource you request could not be found 500";
                    break;
                default:
                    break;
            }

            return View("NotFound");
        }
    }
}
