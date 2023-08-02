using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
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
        [AllowAnonymous]
        [Route("category/writercategorylist")]
        public IActionResult WriterCategoryList()
        {
            var values=cm.GetAllCategories();
            return View(values);
        }
        [AllowAnonymous]
        [Route("category/categoryadd")]
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [Route("category/categoryadd")]
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            cm.AddCategory(category);
            category.CategoryStatus = true;
            return RedirectToAction("WriterCategoryList", "category");
        }
        [AllowAnonymous]
        [Route("category/editcategory/{id}")]
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var category=cm.GetCategoryById(id);
            return View(category);
        }
        [AllowAnonymous]
        [Route("category/editcategory/{id}")]
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            cm.CategoryUpdate(category);
            return RedirectToAction("WriterCategoryList", "category");
        }
        [Route("category/deletecategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var categories = cm.GetCategoryById(id);
            cm.CategoryDelete(categories);
            return RedirectToAction("WriterCategoryList", "category");
        }


    }
}
