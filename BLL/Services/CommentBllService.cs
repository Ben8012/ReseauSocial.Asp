using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentBllService : ICommentBll
    {
        private readonly ICommentDal _commentDal;

        public CommentBllService(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public int AddComment(CommentBll entity)
        {
            return _commentDal.AddComment(entity.CommentBllToCommentDal());
        }

        public int CountByArticleId(int id)
        {
            return _commentDal.CountByArticleId(id);
        }

        public int CountByUserId(int id)
        {
            return _commentDal.CountByUserId(id);
        }

        public IEnumerable<CommentBll> GetAllComment()
        {
            return _commentDal.GetAllComment().Select(c => c.CommentDalToCommentBll());
        }

        public IEnumerable<CommentBll> GetByArticleId(int id)
        {
            return _commentDal.GetByArticleId(id).Select(c => c.CommentDalToCommentBll());
        }

        public CommentBll GetById(int id)
        {
            return _commentDal.GetById(id).CommentDalToCommentBll();
        }

        public IEnumerable<CommentBll> GetByUserId(int id)
        {
            return _commentDal.GetByUserId(id).Select(c => c.CommentDalToCommentBll());
        }
    }
}
