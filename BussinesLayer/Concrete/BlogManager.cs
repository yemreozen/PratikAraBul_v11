using BussinesLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogdal;

        public BlogManager(IBlogDal blogdal)
        {
            _blogdal = blogdal;
        }

        public void AddBlog(Blog blog)
        {
            _blogdal.Insert(blog);
        }

        public void BlogDelete(Blog blog)
        {
            _blogdal.Delete(blog);
        }

        public void BlogUpdate(Blog blog)
        {
            _blogdal.Update(blog);  
        }

        public List<Blog> GetAllBlogs()
        {
           return _blogdal.GetAll();
        }

        public Blog GetBlogById(int id)
        {
            return _blogdal.GetByID(id);
        }
        public List<Blog> GetBlogByID(int id)
        {
            return _blogdal.GetListAll(x => x.BlogID == id);
        }
       
        public List<Blog> GetBlogListWithCategory()
        {
           return _blogdal.GetListWithCategory();
        }
        public List<Blog> GetBlogWithWriter()
        {
            return _blogdal.GetBlogWithWriter();
        }
        public List<Blog> GetLast3Blog()
        {
            return _blogdal.GetListWithCategory().TakeLast(3).ToList();
        }
        public List<Blog> GetFirst3Blog()
        {
            return _blogdal.GetAll().TakeLast(3).ToList();

        }
        public List<Blog> GetLast4BlogWithCategory()
        {
            return _blogdal.GetListWithCategory().TakeLast(4).ToList(); 
        }

        public List<Blog> GetBlogListWithWriter(int id)
        {
            return _blogdal.GetListAll(x => x.WriterID == id);
        }
        public List<Blog> GetBlogListByCategoryId(int id)
        {
            return _blogdal.GetListAll(x => x.CategoryID == id);
        }
        public List<Blog> GetBlogListWithWriterId(int id)
        {
            return _blogdal.GetListWithCategoryByWriter(id);
        }

       
    }
}
