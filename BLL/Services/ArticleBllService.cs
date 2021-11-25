using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using BLL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ArticleBllService : IArticleBll
    {
        private readonly IArticleDal _articleDal;

        public ArticleBllService(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

       

        public void CommentArticle(int articleId, int userId, string message)
        {
            _articleDal.CommentArticle( articleId,  userId,  message);
        }

        public void Delete(int id)
        {
            _articleDal.Delete( id);
        }

        public void Insert(ArticleBll article)
        {
            _articleDal.Insert(article.ArticleBllToArticleDal());
        }

        public void SignalArticle(int articleId, int userId)
        {
            _articleDal.SignalArticle( articleId,  userId);
        }

        public void Update(int id, ArticleBll article)
        {
            _articleDal.Update(id, article.ArticleBllToArticleDal());
        }

        public IEnumerable<ArticleBll> GetAllArticle()
        {
            return _articleDal.GetAllArticle().Select(a => a.ArticleDalToArticleBll());
        }

        public IEnumerable<ArticleBll> GetArticleByUserId(int userId)
        {
            return _articleDal.GetArticleByUserId(userId).Select(a => a.ArticleDalToArticleBll());
        }

        public ArticleBll GetArticleById(int articleId)
        {
            return _articleDal.GetArticleById(articleId).ArticleDalToArticleBll();
        }

        public bool IsSignalByUser(int articleId, int userId)
        {
            return _articleDal.IsSignalByUser(articleId, userId);
        }

        public void UnSignalArticle(int articleId, int userId)
        {
            _articleDal.UnSignalArticle(articleId, userId);
        }
    }
}
