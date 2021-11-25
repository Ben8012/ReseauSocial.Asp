using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IArticleBll
    {
       
        void CommentArticle(int articleId, int userId, string message);
        void Delete(int id);
        void Insert(ArticleBll article);
        void SignalArticle(int articleId, int userId);
        void Update(int id, ArticleBll article);
        IEnumerable<ArticleBll> GetAllArticle();

        IEnumerable<ArticleBll> GetArticleByUserId(int userId);

        ArticleBll GetArticleById(int articleId);

        bool IsSignalByUser(int articleId, int userId);

        void UnSignalArticle(int articleId, int userId);
    }
}
