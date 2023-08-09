using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
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
        public IActionResult Index(int page = 1)
        {
            var values = cm.GetAllCalculationText().ToPagedList(page, 6);
            return View(values);
        }
        [AllowAnonymous]
        [Route("hesaplamaaraclari/{id}/{calculationtitle}")]
        public IActionResult LgsPuanHesaplama(int id)
        {
            ViewBag.Id = id;
            var values = cm.GetCalculationTextByTextId(id);
            return View(values);
        }
     
        [Route("hesaplamaaraclari/yazarhesaplamaiceriklistesi")]
        public IActionResult WriterCalculationTextList(int page=1)
        {
            var values = cm.GetAllCalculationText().ToPagedList(page,10);
            return View(values);
        }
  
        [Route("hesaplamaaraclari/icerikekle")]
        [HttpGet]
        public IActionResult CalculationToolsAddText()
        {

            return View();
        }
        [Route("hesaplamaaraclari/icerikekle")]
        [HttpPost]
        public IActionResult CalculationToolsAddText(CalculationText calculationText)
        {
            cm.AddCalculationText(calculationText);
            return View();
        }
        [Route("hesaplamaaraclari/icerikdüzenle/{id}")]
        [HttpGet]
        public IActionResult CalculationToolsEditText(int id)
        {
            var values = cm.GetCalculationTextById(id);
            return View(values);
        }
        [Route("hesaplamaaraclari/icerikdüzenle/{id}")]
        [HttpPost]
        public IActionResult CalculationToolsEditText(CalculationText calculationText)
        {
            cm.CalculationTextUpdate(calculationText);
            return View();
        }
    }
}
