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
    public class EfCategoryRepository:GenericRepository<Category>,ICategoryDal
    {
        Context c = new Context();

        public Category GetListCategoryByBlogId(int id)
        {
            var category = c.Categories
            .Include(c => c.Blogs) // Include 'Blogs' relationship (optional, if you need additional blog data)
            .FirstOrDefault(c => c.Blogs.Any(b => b.BlogID == id));
            return category;
        }
    }
}
