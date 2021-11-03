using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ReseauSocial.Asp.Mappers;
using ReseauSocial.Asp.Models;
using ReseauSocial.Asp.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Controllers
{
    public class BlacklistController : Controller
    {
        private readonly IUserBllService _userBll;
        private readonly ISessionHelpers _sessionHelpers;
        private readonly IBlacklistBll _blacklistBll;

        public BlacklistController(IUserBllService userBll, ISessionHelpers sessionHelpers, IBlacklistBll blacklistBll)
        {
            _userBll = userBll;
            _sessionHelpers = sessionHelpers;
            _blacklistBll = blacklistBll;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("Blacklist/{id}")]
        public IActionResult Blacklist(int id)
        {
            int blacklisterId = _sessionHelpers.CurentUser.Id;

            if (!_blacklistBll.IsUser1BlacklisterOfUser2(blacklisterId, id))
            {
                _blacklistBll.Blacklist(blacklisterId, id);
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpGet("UnBlacklist/{id}")]
        public IActionResult UnBlacklist(int id)
        {
            int blacklisterId = _sessionHelpers.CurentUser.Id;

            if (_blacklistBll.IsUser1BlacklisterOfUser2(blacklisterId, id))
            {
                _blacklistBll.UnBlacklist(blacklisterId, id);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("GetAllBlacklistedOfOneUser")]
        public IActionResult GetAllBlacklistedOfOneUser()
        {
            // verifier si l utilisateur n'est pas bloqué ici TODO
            IEnumerable<UserAsp> listUsers = _blacklistBll.GetAllBlacklistedOfOneUser(_sessionHelpers.CurentUser.Id)
                .Select(u => u.UserBllToUserAsp());

            return View(listUsers);
        }

        [HttpGet("GetAllBlacklisterOfOneUser")]
        public IActionResult GetAllBlacklisterOfOneUser()
        {
            // verifier si l utilisateur n'est pas bloqué ici TODO
            IEnumerable<UserAsp> listUsers = _blacklistBll.GetAllBlacklisterOfOneUser(_sessionHelpers.CurentUser.Id)
                .Select(u => u.UserBllToUserAsp());

            return View(listUsers);
        }

    }
}
/*   
    // liste de tout les utilisateur qui sont blacklister au moins par qlq un 
    IEnumerable<UserBll> GetAllBlacklisted();
    //liste de tout les utilisateurs qui ont blacklister au moins qlq un
    IEnumerable<UserBll> GetAllBlacklister();
          
 */