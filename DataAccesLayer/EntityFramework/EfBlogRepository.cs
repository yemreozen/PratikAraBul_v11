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
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        Context c = new Context();
        public List<Blog> GetListWithCategory()
        {
            return c.Blogs.Include(x => x.Category).ToList();
        }
        public List<Blog> GetBlogWithWriter()
        {
            return c.Blogs.Include(x => x.Writer).ToList();
        }
    }
}
