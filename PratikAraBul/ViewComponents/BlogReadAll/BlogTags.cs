using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PratikAraBul.ViewComponents.BlogReadAll
{
    public class BlogTags:ViewComponent
    {
        BlogTagManager bm = new BlogTagManager(new EfBlogTagRepository());

        public IViewComponentResult Invoke(int id)
        {
            var values = bm.GetBlogTagById(id);
            return View(values);
        }
    }
}
