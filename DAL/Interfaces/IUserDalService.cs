using DAL.Models;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IUserDalService
    {
        void ReactivateStatus(int ChangedUserId);
        void AskActivateStatus(int ChangedUserId);
        void AskDeleteStatus(int ChangedUserId);
        void BlockedStatus(int ChangedUserId, int EditorUserId);
        void DeactivateStatus(int ChangUserId);
        void Delete(int id);
        void DeleteStatus(int ChangedUserId, int EditorUserId);
        bool EmailExists(string email);

        UserDal Login(string email, string passwd);
        
        void Register(UserDal entity);
        void Update(int id, UserDal entity);

        StatusDal GetStatus(int userId);

        UserDal GetUser(int userId);

        IEnumerable<UserDal> GetAllUsers();
    }
}