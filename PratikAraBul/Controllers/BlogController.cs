using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PratikAraBul.Controllers
{
    
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
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
      
        public IActionResult BlogListWithWriter()
        {
            var values =bm.GetBlogListWithWriterId(1);
            return View(values);
        }
     
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetAllCategories()
                                                   select new SelectListItem
                                                   {
                                                       Text =x.CategoryName,
                                                       Value=x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv=categoryValues;
            return View();
        }
        
        [HttpPost]
        public IActionResult BlogAdd(Blog b)
        {
            b.BlogStatus = true;
            b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            b.WriterID=1;
            bm.AddBlog(b);
            return RedirectToAction("bloglistwithwriter","blog");
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogValue=bm.GetBlogById(id);
            bm.BlogDelete(blogValue);
            return RedirectToAction("bloglistwithwriter", "blog");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {

            List<SelectListItem> categoryValues = (from x in cm.GetAllCategories()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            var blogValue=bm.GetBlogById(id);
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            b.BlogStatus = true;
            b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            b.WriterID = 1;
            bm.BlogUpdate(b);
           return RedirectToAction("bloglistwithwriter", "blog");
        }

    }
}
