using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PratikAraBul.Controllers
{
    public class WriterController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
       public PartialViewResult WriterSideBarPartial(int id)
        {
            return PartialView();
        }
    }
}
