using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PratikAraBul.ViewComponents.HomeTreeSection
{
    public class HomeTreeSection :ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = bm.GetLast3Blog();
            return View(values);
        }
    }
}
