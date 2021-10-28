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
        private readonly ILogger<HomeController> _logger;

        public HomeController(IArticleBll articleBll, ISessionHelpers sessionHelpers, ILogger<HomeController> logger)
        {
            _articleBll = articleBll;
            _sessionHelpers = sessionHelpers;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<ArticleAsp> listArticles = _articleBll.GetAllArticle().OrderByDescending(a => a.Date).Take(10).Select(a => a.ArticleBllToArticleAsp());
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
