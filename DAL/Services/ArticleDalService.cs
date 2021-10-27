using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ArticleDalService : AbstracService, IArticleDal
    {
        public void BlockArticle(int articleId, int AdminId, string message)
        {
            throw new NotImplementedException();
        }

        public void CommentArticle(int articleId, int userId, string message)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ArticleDal article)
        {
            throw new NotImplementedException();
        }

        public void SignalArticle(int articleId, int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ArticleDal article)
        {
            throw new NotImplementedException();
        }
    }
}
