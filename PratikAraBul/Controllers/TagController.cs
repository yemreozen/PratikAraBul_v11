using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace PratikAraBul.Controllers
{
    [AllowAnonymous]
    public class TagController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        BlogTagManager bmt = new BlogTagManager(new EfBlogTagRepository());
        public IActionResult Index()
        {
            var values = bmt.GetTagsWithBlog();
            return View(values);
        }
        [HttpGet]
        public IActionResult TagAdd()
        {
            List<SelectListItem> blogValues = (from x in bm.GetAllBlogs()
                                                   select new SelectListItem
                                                   {
                                                     Text=x.BlogTitle,
                                                     Value=x.BlogID.ToString()
                                                   }).ToList();
            ViewBag.cv = blogValues;
            return View();
        }
        [HttpPost]
        public IActionResult TagAdd(BlogTags blogTags)
        {
            bmt.AddBlogTag(blogTags);
            return RedirectToAction("index", "Tag");
        }
        public IActionResult DeleteTag(int id)
        {
            var tagValue = bmt.GetTagsById(id);
            bmt.BlogBlogTagDelete(tagValue);
            return RedirectToAction("index", "tag");
        }
    }
}
