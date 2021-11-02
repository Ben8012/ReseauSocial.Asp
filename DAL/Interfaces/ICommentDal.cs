using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICommentDal
    {
        IEnumerable<CommentDal> GetAllComment();
        IEnumerable<CommentDal> GetByUserId(int id);
        IEnumerable<CommentDal> GetByArticleId(int id);
        CommentDal GetById(int id);
        int CountByUserId(int id);
        int CountByArticleId(int id);
        int AddComment(CommentDal entity);
    }
}
