using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PratikAraBul.ViewComponents.MenuCategoryByBlog
{
    public class MenuCategoryByBlog:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BlogManager bm = new BlogManager(new EfBlogRepository());
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
    }
}
