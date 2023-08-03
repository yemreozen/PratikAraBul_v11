using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace PratikAraBul.Controllers
{
    public class CalculationToolsController : Controller
    {
        CalculationTextManager cm = new CalculationTextManager(new EfCalculationText());
        [AllowAnonymous]
        [Route("hesaplamaaraclari")]
        public IActionResult Index(int page =1)
        {
            var values =cm.GetAllCalculationText().ToPagedList(page,6);
            return View(values);
        }
        [AllowAnonymous]
        [Route("hesaplamaaraclari/{id}/{calculationtitle}")]
        public IActionResult LgsPuanHesaplama(int id)
        {
            ViewBag.Id = id;
            var values=cm.GetCalculationTextById(id);
            return View(values);
        }
    }
}
