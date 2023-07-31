using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PratikAraBul.Controllers
{
    public class CategoryController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        [AllowAnonymous]
        [Route("category/{id}/{categoryname?}")]
        public IActionResult Index(int id)
        {
            ViewBag.Id = id;
            var values = bm.GetBlogListByCategoryId(id);
            return View(values);
        }
       
    }
}
