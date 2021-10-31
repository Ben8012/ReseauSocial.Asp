using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using ReseauSocial.Asp.Mappers;
using ReseauSocial.Asp.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageBll _messageService;
        private readonly IUserBllService _userService;
        private readonly ISessionHelpers _sessionHelpers;

        public MessageController(IMessageBll messageService, IUserBllService userService, ISessionHelpers sessionHelpers)
        {
            _messageService = messageService;
            _userService = userService;
            _sessionHelpers = sessionHelpers;
        }

        public IActionResult Index()
        {
            if (_sessionHelpers.CurentUser is null)
                return RedirectToAction("Index", "Home");

            IEnumerable<UserBll> listUsers = _userService.GetAllUsers().Where(u => u.Id != _sessionHelpers.CurentUser.Id);

            return View(listUsers);
        }

        [HttpGet("MessageTo/{id}")]
        public IActionResult MessageTo( int id)
        {     
            if(_sessionHelpers.CurentUser is not null && _sessionHelpers.CurentUser.Id != id)
            {
                UserBll user = _userService.GetUser(id);
                if(user != null)
                {
                    return View(user);
                }     
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
