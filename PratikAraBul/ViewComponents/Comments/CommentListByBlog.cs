using BussinesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace PratikAraBul.ViewComponents.Comments
{
    public class CommentListByBlog :ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id )
        {
            var values = cm.GetAllComments(id );
            return View(values);
        }
    }
}
