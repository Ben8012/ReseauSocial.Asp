using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserBllService
    {
        void AskActivateStatus(int ChangedUserId);
        void AskDeleteStatus(int ChangedUserId);
        void BlockedStatus(int ChangedUserId, int EditorUserId);
        void DeactivateStatus(int ChangUserId);
        void Delete(int id);
        void DeleteStatus(int ChangedUserId, int EditorUserId);
        bool EmailExists(string email);
        UserBll Login(string email, string passwd);
        void ReactivateStatus(int ChangedUserId);
        void Register(UserBll entity);
        void Update(int id, UserBll entity);

        StatusBll GetStatus(int userId);

        UserBll GetUser(int userId);

        IEnumerable<UserBll> GetAllUsers();
    }
}