using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using DataAccesLayer.Concrete;
using System.Linq;

namespace PratikAraBul.ViewComponents
{
    public class WriterLayout:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            var model = new Writer
            {
                WriterName = writerName,
            };
            return View(model);
        }
    }
}
