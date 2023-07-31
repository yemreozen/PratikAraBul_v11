using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IBlogService
    {
        void AddBlog(Blog blog);
        void BlogDelete(Blog blog);
        void BlogUpdate(Blog blog);
        List<Blog> GetAllBlogs();
        Blog GetBlogById(int id);
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogWithWriter();
        List<Blog> GetBlogListWithWriter(int id);
    }
}
