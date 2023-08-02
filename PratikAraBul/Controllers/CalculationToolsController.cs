using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PratikAraBul.Controllers
{
    public class CalculationToolsController : Controller
    {
        [AllowAnonymous]
        [Route("hesaplamaaraclari")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("hesaplamaaraclari/lgspuanhesaplama")]
        public IActionResult LgsPuanHesaplama()
        {
            return View();
        }
    }
}
