using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;
using BLL.Interfaces;

namespace BLL.Services
{
    public class UserBllService : IUserBllService
    {
        private readonly IUserDalService _userDalService;

        public UserBllService(IUserDalService userDalService)
        {
            _userDalService = userDalService;
        }

        public void AskActivateStatus(int ChangedUserId, string token)
        {
            _userDalService.AskActivateStatus(ChangedUserId, token);
        }

        public void AskDeleteStatus(int ChangedUserId, string token)
        {
            _userDalService.AskDeleteStatus(ChangedUserId, token);
        }

     
        public void DeactivateStatus(int ChangUserId, string token)
        {
            _userDalService.DeactivateStatus(ChangUserId, token);
        }

        public void Delete(int id, string token)
        {
            _userDalService.Delete(id, token);
        }

       

        public bool EmailExists(string email)
        {
            return _userDalService.EmailExists(email);
        }


        public UserBll Login(string email, string passwd)
        {
            return _userDalService.Login(email, passwd).DalUserToBllUser();
        }

        public void ReactivateStatus(int ChangedUserId, string token)
        {
            _userDalService.ReactivateStatus(ChangedUserId, token);
        }

        public void Register(UserBll entity)
        {
            _userDalService.Register(entity.UserBllToUserDal());
        }

        public void Update(int id, UserBll entity, string token)
        {
            _userDalService.Update(id, entity.UserBllToUserDal(), token);
        }

        public StatusBll GetStatus(int userId, string token)
        {
           return _userDalService.GetStatus(userId, token).DalStatusToBllStatus();
        }

        public UserBll GetUser(int userId, string token)
        {
            return _userDalService.GetUser(userId, token).DalUserToBllUser();
        }

        public IEnumerable<UserBll> GetAllUsers( string token)
        {
            return _userDalService.GetAllUsers(token).Select(u => u.DalUserToBllUser());
        }
    }
}
