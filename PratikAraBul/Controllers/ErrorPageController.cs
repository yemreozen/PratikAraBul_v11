using Microsoft.AspNetCore.Mvc;

namespace PratikAraBul.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code)
        {
            return View();
        }
    }
}
