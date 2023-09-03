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
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity;
using DataAccesLayer.Concrete;
using System.IO;
using Microsoft.AspNetCore.Http;
using X.PagedList;
using Microsoft.AspNetCore.Hosting;

namespace PratikAraBul.Controllers
{

    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        private readonly IWebHostEnvironment _hostEnviroment;

        public BlogController(IWebHostEnvironment hostEnviroment)
        {
            _hostEnviroment = hostEnviroment;
        }

        [AllowAnonymous]
        public IActionResult Index(int page =1)
        {
            var values = bm.GetBlogListWithCategory().ToPagedList(page,2);
            return View(values);
        }
        [AllowAnonymous]
        [Route("blog/blogallread/{id}/{blogtitle?}")]
        public IActionResult BlogAllRead(int id)
        {
            ViewBag.Id = id;
            var categories = cm.GetListCategoryByBlogId(id);
            if (categories != null)
            {
                ViewBag.CategoryID = categories.CategoryID;
                ViewBag.CategoryName = categories.CategoryName;
            }

            var values = bm.GetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListWithWriter(int page =1)
        {
            var userMail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = bm.GetBlogListWithWriterId(writerId).ToPagedList(page,10);
            return View(values);
        }

        [HttpGet]
        [Route("blog/blogadd")]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetAllCategories()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
      
        [HttpPost]
        [Route("blog/blogadd")]
        public IActionResult BlogAdd(BlogImageAdd b)
        {
            var userMail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            Blog bl = new Blog();

            string wwwRootPath = _hostEnviroment.WebRootPath;
            if (b.ThumbnailImage != null)
            {
                var extension = Path.GetExtension(b.ThumbnailImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), wwwRootPath +"/images/", newimagename);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    b.ThumbnailImage.CopyTo(stream);
                }
                bl.ThumbnailImage = "/images/" + newimagename; // Save the image file name to the model property
            }

            if (b.Image != null)
            {
                var extension = Path.GetExtension(b.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), wwwRootPath + "/images/", newimagename);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    b.Image.CopyTo(stream);
                }
                bl.Image = "/images/" + newimagename; // Save the image file name to the model property
            }

            bl.BlogTitle = b.BlogTitle;
            bl.BlogCaption = b.BlogCaption;
            bl.BlogContent = b.BlogContent;
            bl.BlogStatus = true;
            bl.CategoryID = b.CategoryID;
            bl.BlogCreateDate = DateTime.Now;
            bl.WriterID = writerId;
            bm.AddBlog(bl);

            return RedirectToAction("bloglistwithwriter", "blog");
        }
        [Route("blog/deleteblog/{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var blogValue = bm.GetBlogById(id);
            bm.BlogDelete(blogValue);
            return RedirectToAction("bloglistwithwriter", "blog");
        }
        [HttpGet]
        [Route("blog/editblog/{id}")]
        public IActionResult EditBlog(int id)
        {

            List<SelectListItem> categoryValues = (from x in cm.GetAllCategories()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            var blogValue = bm.GetBlogById(id);
            return View(blogValue);
        }
       
        [HttpPost]
        [Route("blog/editblog/{id}")]
        public IActionResult EditBlog(Blog b, IFormFile thumbnailImageFile, IFormFile imageFile)
        {
            if (thumbnailImageFile != null)
            {
                var extension = Path.GetExtension(thumbnailImageFile.FileName);
                var newImageName = Guid.NewGuid() + extension;
                string wwwRootPath = _hostEnviroment.WebRootPath;

                var location = Path.Combine(Directory.GetCurrentDirectory(), wwwRootPath + "/images/", newImageName);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    thumbnailImageFile.CopyTo(stream);
                }
                b.ThumbnailImage = "/images/" + newImageName; // Save the image file name to the model property
            }

            if (imageFile != null)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var newImageName = Guid.NewGuid() + extension;
                string wwwRootPath = _hostEnviroment.WebRootPath;
                var location = Path.Combine(Directory.GetCurrentDirectory(), wwwRootPath + "/images/", newImageName);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                b.Image = "/images/" + newImageName; // Save the image file name to the model property
            }

            b.BlogStatus = true;
            b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            bm.BlogUpdate(b);
            return RedirectToAction("bloglistwithwriter", "blog");
        }


    }
}
