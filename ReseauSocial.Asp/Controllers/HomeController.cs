using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReseauSocial.Asp.Mappers;
using ReseauSocial.Asp.Models;
using ReseauSocial.Asp.Sessions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleBll _articleBll;
        private readonly ISessionHelpers _sessionHelpers;
        private readonly IUserBllService _userBll;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IArticleBll articleBll, ISessionHelpers sessionHelpers, ILogger<HomeController> logger, IUserBllService userBll)
        {
            _articleBll = articleBll;
            _sessionHelpers = sessionHelpers;
            _logger = logger;
            _userBll = userBll;

        }

        public IActionResult Index()
        {
            IEnumerable<ArticleAsp> listArticles = _articleBll.GetAllArticle()
                .Where(a => a.OnLigne)
                .OrderByDescending(a => a.Date)
                .Take(10)
                .Select(a =>{
                    ArticleAsp article = a.ArticleBllToArticleAsp();
                    article.UserArticle = _userBll.GetUser(a.UserId, null).UserBllToUserAsp();
                    return article;
                });
              
            return View(listArticles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
