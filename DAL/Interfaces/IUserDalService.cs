using DAL.Models;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IUserDalService
    {
        void ReactivateStatus(int ChangedUserId, string token);
        void AskActivateStatus(int ChangedUserId, string token);
        void AskDeleteStatus(int ChangedUserId, string token);
        void BlockedStatus(int ChangedUserId, int EditorUserId, string token);
        void DeactivateStatus(int ChangUserId, string token);
        void Delete(int id, string token);
        void DeleteStatus(int ChangedUserId, int EditorUserId, string token);
        bool EmailExists(string email);

        UserDal Login(string email, string passwd);
        
        void Register(UserDal entity);
        void Update(int id, UserDal entity, string token);

        StatusDal GetStatus(int userId, string token);

        UserDal GetUser(int userId, string token);

        IEnumerable<UserDal> GetAllUsers(string token);
    }
}