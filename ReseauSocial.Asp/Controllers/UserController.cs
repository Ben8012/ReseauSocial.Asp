using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using ReseauSocial.Asp.Mappers;
using ReseauSocial.Asp.Models;
using ReseauSocial.Asp.Models.Forms;
using ReseauSocial.Asp.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBllService _userBllService;
        private readonly ISessionHelpers _sessionHelpers;
        private readonly IMessageBll _messageBll;

        public UserController(IUserBllService userBllService, ISessionHelpers sessionHelpers, IMessageBll messageBll)
        {
            _userBllService = userBllService;
            _sessionHelpers = sessionHelpers;
            _messageBll = messageBll;
        }

        public IActionResult Index()
        {
            if(_sessionHelpers.CurentUser is not null)
            {
                IEnumerable<UserAsp> listUsers = _userBllService.GetAllUsers()
                    .Where(u => u.Id != _sessionHelpers.CurentUser.Id)
                    .Select(u => u.UserBllToUserAsp());
                return View(listUsers);
            }
            return RedirectToAction("Index", "Home");
        }


       
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUser entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            _userBllService.Register(entity.RegisterUserToUserBll());

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUser entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            UserBll user = _userBllService.Login(entity.Email, entity.Passwd);
           
            if (user is null)
            {
                return View(entity);
            }
          
            _sessionHelpers.CurentUser = new UserSession { 
                Id = user.Id,
                Email = user.Email,
                Token = null
            };
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            _sessionHelpers.clearUserSession();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AskActivateStatus(int ChangedUserId)
        {
            _userBllService.AskActivateStatus(ChangedUserId);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult DeactivateStatus(int ChangUserId)
        {
            _userBllService.DeactivateStatus(ChangUserId);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AskDeleteStatus(int ChangedUserId)
        {
            _userBllService.AskDeleteStatus(ChangedUserId);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult EmailExists(string email)
        {
            _userBllService.EmailExists(email);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Update(int id)
        {
            UserAsp user = _userBllService.GetUser(_sessionHelpers.CurentUser.Id).UserBllToUserAsp();
            if (user.Id != id)
                return RedirectToAction("Index");
            UpdateUser updateUser = new UpdateUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
              
            };
            return View(updateUser);
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateUser entity)
        {
            if (!ModelState.IsValid)
                return View(entity);

            _userBllService.Update( id,  entity.UpdateUserToUserBll());
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return View();
        }

        
        public IActionResult ProfilUser()
        {

            UserAsp user = _userBllService.GetUser(_sessionHelpers.CurentUser.Id).UserBllToUserAsp();
            
            ProfileUser profil = new ProfileUser { 
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Id = user.Id,
                Status = _userBllService.GetStatus(user.Id)
            };
            return View(profil);
        }


        public IActionResult MyConctacts()
        {
           IEnumerable<UserAsp> listMyContacts = _messageBll.GetAllMessagesOfUser(_sessionHelpers.CurentUser.Id)
                .Select(m => m.UserSend != _sessionHelpers.CurentUser.Id ? m.UserSend : m.UserGet)
                .Distinct()
                .Select(id => _userBllService.GetUser(id).UserBllToUserAsp()) ;


            return View(listMyContacts);
        }

    }
}

