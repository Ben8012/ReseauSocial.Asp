using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserBllService
    {
        void ReactivateStatus(int ChangedUserId, string token);
        void AskActivateStatus(int ChangedUserId, string token);
        void AskDeleteStatus(int ChangedUserId, string token);
       
        void DeactivateStatus(int ChangUserId, string token);
        void Delete(int id, string token);
      
        bool EmailExists(string email);

        UserBll Login(string email, string passwd);

        void Register(UserBll entity);
        void Update(int id, UserBll entity, string token);

        StatusBll GetStatus(int userId, string token);

        UserBll GetUser(int userId, string token);

        IEnumerable<UserBll> GetAllUsers(string token);
    }
}