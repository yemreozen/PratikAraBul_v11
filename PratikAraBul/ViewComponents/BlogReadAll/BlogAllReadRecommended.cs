using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace PratikAraBul.ViewComponents.BlogReadAll
{
    public class BlogAllReadRecommended:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values=bm.GetLast4BlogWithCategory();
            var categories = bm.GetBlogListWithCategory();
            var combinedResult = new Tuple<List<Blog>, List<Blog>>(categories, values);

            return View(combinedResult);
        }
    }
}
