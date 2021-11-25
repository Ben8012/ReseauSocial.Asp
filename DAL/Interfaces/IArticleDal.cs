using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IArticleDal
    {
       
        void CommentArticle(int articleId, int userId, string message);
        void Delete(int id);
        void Insert(ArticleDal article);
        void SignalArticle(int articleId, int userId);
        void Update(int id, ArticleDal article);

        IEnumerable<ArticleDal> GetAllArticle();

        IEnumerable<ArticleDal> GetArticleByUserId(int userId);

        ArticleDal GetArticleById(int articleId);

        bool IsSignalByUser(int articleId, int userId);

        void UnSignalArticle(int articleId, int userId);
    }
}
