using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFollowerDal
    {
        void Follow(int followerId, int followedId);


        void UnFollow(int followerId, int followedId);


        // liste de tout les utilisateur qui suivent 
        IEnumerable<UserDal> GetAllFollower();


        //liste de tout les utilisateurs qui sont suivit 
        IEnumerable<UserDal> GetAllFollowed();


        //liste des utilisateurs qui suivent l'utilisateur en cours
        IEnumerable<UserDal> GetAllFollowersOfOneUser(int followedId);


        // liste des utilisateurs qui sont suivit par l'utilisateur en cours
        IEnumerable<UserDal> GetAllFollowedOfOneUser(int followerId);

    }
}
