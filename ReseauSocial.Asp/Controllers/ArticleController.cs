using BLL.Interfaces;
using BLL.Models;
using ReseauSocial.Asp.Mappers;
using Microsoft.AspNetCore.Mvc;
using ReseauSocial.Asp.Models.Forms;
using ReseauSocial.Asp.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReseauSocial.Asp.Models;

namespace ReseauSocial.Asp.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleBll _articleBll;
        private readonly ICommentBll _commentBll;
        private readonly ISessionHelpers _sessionHelpers;

        public ArticleController(IArticleBll articleBll, ICommentBll commentBll, ISessionHelpers sessionHelpers)
        {
            _articleBll = articleBll;
            _commentBll = commentBll;
            _sessionHelpers = sessionHelpers;
        }

        public IActionResult Index()
        {
            IEnumerable<ArticleAsp> listArticles = _articleBll.GetAllArticle().Select(a => a.ArticleBllToArticleAsp());
            return View(listArticles);
        }

        [HttpGet]
        public IActionResult CommentArticle(int articleId)
        {
            ArticleBll article = _articleBll.GetArticleById(articleId);
            Comment comment = new Comment();
            comment.Article = article;
            return View(comment);
        }
        /*
                [HttpPost]
                public IActionResult CommentArticle(int articleId, Comment form)
                {
                    _articleDal.CommentArticle(articleId, userId, message);

                }*/

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _articleBll.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(ArticleForm form)
        {
            if (!ModelState.IsValid)
                return View(form);
            _articleBll.Insert(
                new ArticleBll {
                    Title = form.Title,
                    Content = form.Content,
                    CommentOk = form.CommentOk,
                    OnLigne = form.OnLigne,
                    UserId = _sessionHelpers.CurentUser.Id
                });
            return RedirectToAction("Index");
        }

        [HttpGet("SignalArticle/{id}")]
        public IActionResult SignalArticle(int id)
        {
            ArticleBll article = _articleBll.GetArticleById(id);

            if (article.UserId != _sessionHelpers.CurentUser.Id)
                 _articleBll.SignalArticle(id, _sessionHelpers.CurentUser.Id);

            return RedirectToAction("Index");
        }

        [HttpGet("Update/{id}")]
        public IActionResult Update(int id)
        {
            ArticleBll article = _articleBll.GetArticleById(id);

            if (article.UserId == _sessionHelpers.CurentUser.Id)
            {
                UpdateArticleForm form = new UpdateArticleForm
                {
                    Title = article.Title,
                    Content = article.Content,
                    CommentOk = article.CommentOk,
                    OnLigne = article.OnLigne
                };
                return View(form);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("Update/{id}")]
        public IActionResult Update(int id, UpdateArticleForm form)
        {
            if (!ModelState.IsValid)
                return View(form);
            _articleBll.Update(id,
                new ArticleBll
                {
                    Title = form.Title,
                    Content = form.Content,
                    CommentOk = form.CommentOk,
                    OnLigne = form.OnLigne,
                    UserId = _sessionHelpers.CurentUser.Id
                });
            return RedirectToAction("Index");
        }


        [HttpGet("GetArticleById/{id}")]
        public IActionResult GetArticleById(int id)
        {
            ArticleAsp article = _articleBll.GetArticleById(id).ArticleBllToArticleAsp();
            return View(article);

        }

        [HttpGet("GetArticleByUserId/{id}")]
        public IActionResult GetArticleByUserId(int id)
        {
            IEnumerable<ArticleAsp> listArticles = _articleBll.GetArticleByUserId(id).Select(a => a.ArticleBllToArticleAsp());
            return View(listArticles);
        }

        [HttpGet("GetMyArticle")]
        public IActionResult GetMyArticle()
        {
            IEnumerable<ArticleAsp> listArticles = _articleBll.GetArticleByUserId(_sessionHelpers.CurentUser.Id).Select(a => a.ArticleBllToArticleAsp());
            return View(listArticles);
        }
    }
}


