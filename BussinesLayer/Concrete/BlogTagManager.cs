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
    public class BlogTagManager : IBlogTagService
    {
        IBlogTagsDal _blogTagsDal;

        public BlogTagManager(IBlogTagsDal blogTagsDal)
        {
            _blogTagsDal = blogTagsDal;
        }

        public void AddBlogTag(BlogTags blogtags)
        {
            throw new NotImplementedException();
        }

        public void BlogBlogTagDelete(BlogTags blog)
        {
            throw new NotImplementedException();
        }

        public void BlogBlogTagUpdate(BlogTags blog)
        {
            throw new NotImplementedException();
        }

        public List<BlogTags> GetAllBlogTag()
        {
            throw new NotImplementedException();
        }

        public List<BlogTags> GetBlogTagById(int id)
        {
            return _blogTagsDal.GetListAll(x=>x.BlogID==id);
        }
    }
}
