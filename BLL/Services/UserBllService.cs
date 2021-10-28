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

        public void AskActivateStatus(int ChangedUserId)
        {
            _userDalService.AskActivateStatus(ChangedUserId);
        }

        public void AskDeleteStatus(int ChangedUserId)
        {
            _userDalService.AskDeleteStatus(ChangedUserId);
        }

        public void BlockedStatus(int ChangedUserId, int EditorUserId)
        {
            _userDalService.BlockedStatus(ChangedUserId, EditorUserId);
        }

        public void DeactivateStatus(int ChangUserId)
        {
            _userDalService.DeactivateStatus(ChangUserId);
        }

        public void Delete(int id)
        {
            _userDalService.Delete(id);
        }

        public void DeleteStatus(int ChangedUserId, int EditorUserId)
        {
            _userDalService.DeleteStatus(ChangedUserId, EditorUserId);
        }

        public bool EmailExists(string email)
        {
            return _userDalService.EmailExists(email);
        }


        public UserBll Login(string email, string passwd)
        {
            return _userDalService.Login(email, passwd).DalUserToBllUser();
        }

        public void ReactivateStatus(int ChangedUserId)
        {
            _userDalService.ReactivateStatus(ChangedUserId);
        }

        public void Register(UserBll entity)
        {
            _userDalService.Register(entity.UserBllToUserDal());
        }

        public void Update(int id, UserBll entity)
        {
            _userDalService.Update(id, entity.UserBllToUserDal());
        }

        public StatusBll GetStatus(int userId)
        {
           return _userDalService.GetStatus(userId).DalStatusToBllStatus();
        }

        public UserBll GetUser(int userId)
        {
            return _userDalService.GetUser(userId).DalUserToBllUser();
        }

        public IEnumerable<UserBll> GetAllUsers()
        {
            return _userDalService.GetAllUsers().Select(u => u.DalUserToBllUser());
        }
    }
}
