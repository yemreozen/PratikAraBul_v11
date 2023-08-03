using BussinesLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
            _blogTagsDal.Insert(blogtags);

        }

        public void BlogBlogTagDelete(BlogTags blogtags)
        {
            _blogTagsDal.Delete(blogtags);
        }

        public void BlogBlogTagUpdate(BlogTags blogtags)
        {
            throw new NotImplementedException();
        }

        public List<BlogTags> GetAllBlogTag()
        {
            return _blogTagsDal.GetAll();
        }

        public List<BlogTags> GetBlogTagById(int id)
        {
            return _blogTagsDal.GetListAll(x=>x.BlogID==id);
        }

        public BlogTags GetTagsById(int id)
        {
            return _blogTagsDal.GetByID(id);
        }

        public List<BlogTags> GetTagsWithBlog()
        {
            return _blogTagsDal.GetTagsWithBlog();
        }
    }
}
