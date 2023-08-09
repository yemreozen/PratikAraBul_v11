using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace PratikAraBul.Controllers
{
    public class ContactController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [Route("gizlilik-politikasi")]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
        [AllowAnonymous]
        [Route("cerez-politikasi")]
        public IActionResult CookiePolicy()
        {
            return View();
        }
    }
}
