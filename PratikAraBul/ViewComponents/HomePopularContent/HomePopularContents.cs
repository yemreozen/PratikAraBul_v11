using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PratikAraBul.ViewComponents.HomePopularContent
{
    public class HomePopularContents:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetFirst3Blog();
            return View(values);
        }
    }
}
