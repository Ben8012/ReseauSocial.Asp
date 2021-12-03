using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ReseauSocial.Asp.Models;
using ReseauSocial.Asp.Sessions;
using ReseauSocial.Asp.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Controllers
{
    public class FollowerController : Controller
    {
        private readonly IUserBllService _userBll;
        private readonly ISessionHelpers _sessionHelpers;
        private readonly IFollowerBll _followerBll;

        public FollowerController(IUserBllService userBll, ISessionHelpers sessionHelpers, IFollowerBll followerBll)
        {
            _userBll = userBll;
            _sessionHelpers = sessionHelpers;
            _followerBll = followerBll;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Follow/{id}")]
        public IActionResult Follow(int id)
        {
            int followerId = _sessionHelpers.CurentUser.Id;

            if (!_followerBll.IsFollowBy(followerId, id))
            {
                _followerBll.Follow(followerId, id);
            }

            return RedirectToAction("Index", "User");
        }

        [HttpGet("UnFollow/{id}")]
        public IActionResult UnFollow(int id)
        {
            int followerId = _sessionHelpers.CurentUser.Id;

            if (_followerBll.IsFollowBy( followerId, id))
            {
                _followerBll.UnFollow(followerId, id);
            }

            return RedirectToAction("Index", "User");
        }

        [HttpGet("GetAllFollowersOfOneUser")]
        public IActionResult GetAllFollowersOfOneUser()
        {
            // verifier si l utilisateur n'est pas bloqué ici TODO
            IEnumerable<UserAsp> listUsers = _followerBll.GetAllFollowersOfOneUser(_sessionHelpers.CurentUser.Id)
                .Select(u => u.UserBllToUserAsp());

            return View(listUsers);
        }


        [HttpGet("GetAllFollowedOfOneUser")]
        public IActionResult GetAllFollowedOfOneUser()
        {
            // verifier si l utilisateur n'est pas bloqué ici TODO
            IEnumerable<UserAsp> listUsers = _followerBll.GetAllFollowedOfOneUser(_sessionHelpers.CurentUser.Id)
                .Select(u => u.UserBllToUserAsp());

            return View(listUsers);
        }

    }
}
/* 

        // liste de tout les utilisateur qui suivent 
        IEnumerable<UserBll> GetAllFollower();


        //liste de tout les utilisateurs qui sont suivit 
        IEnumerable<UserBll> GetAllFollowed();


*/