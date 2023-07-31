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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentdal;

        public CommentManager(ICommentDal commentdal)
        {
            _commentdal = commentdal;
        }

        public void AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllComments(int id)
        {
            return _commentdal.GetListAll(x => x.BlogID == id);
        }
    }
}
