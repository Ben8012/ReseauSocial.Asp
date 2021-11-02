using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFollowerBll
    {

        void Follow(int followerId, int followedId);


        void UnFollow(int followerId, int followedId);


        // liste de tout les utilisateur qui suivent 
        IEnumerable<UserBll> GetAllFollower();


        //liste de tout les utilisateurs qui sont suivit 
        IEnumerable<UserBll> GetAllFollowed();


        //liste des utilisateurs qui suivent l'utilisateur en cours
        IEnumerable<UserBll> GetAllFollowersOfOneUser(int followedId);


        // liste des utilisateurs qui sont suivit par l'utilisateur en cours
        IEnumerable<UserBll> GetAllFollowedOfOneUser(int followerId);

        bool IsFollowBy(int followerId, int followedId);
    }
}
