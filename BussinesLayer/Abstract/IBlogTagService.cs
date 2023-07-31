using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IBlogTagService
    {
        void AddBlogTag(BlogTags blogtags);
        void BlogBlogTagDelete(BlogTags blog);
        void BlogBlogTagUpdate(BlogTags blog);
        List<BlogTags> GetAllBlogTag();
        List<BlogTags> GetBlogTagById(int id);
    }
}
