using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentBll
    {
        IEnumerable<CommentBll> GetAllComment();
        IEnumerable<CommentBll> GetByUserId(int id);
        IEnumerable<CommentBll> GetByArticleId(int id);
        CommentBll GetById(int id);
        int CountByUserId(int id);
        int CountByArticleId(int id);
        int AddComment(CommentBll entity);
    }
}
