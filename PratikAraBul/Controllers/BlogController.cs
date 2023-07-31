using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace PratikAraBul.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        [Route("blog/blogallread/{id}/{blogtitle?}")]
        public IActionResult BlogAllRead(int id)
        {
            ViewBag.Id = id;
            var categories = cm.GetListCategoryByBlogId(id);
            if(categories != null)
            {
                ViewBag.CategoryID = categories.CategoryID;
                ViewBag.CategoryName = categories.CategoryName;
            }
          
            var values = bm.GetBlogByID(id);
            return View(values);


        }
    }
}
