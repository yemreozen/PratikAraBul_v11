using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfBlogTagRepository : GenericRepository<BlogTags>, IBlogTagsDal
    {
        Context c = new Context();
        public List<BlogTags> GetTagsWithBlog()
        {
            return c.BlogsTags.Include(x => x.Blog).ToList();
        }
     
       
    }
}
