using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBlacklistDal
    {
        void Blacklist(int blacklisterId, int blacklistedId);


        void UnBlacklist(int blacklisterId, int blacklistedId);


        // liste de tout les utilisateur qui sont blacklister au moins par qlq un 
        IEnumerable<UserDal> GetAllBlacklisted();


        //liste de tout les utilisateurs qui ont blacklister au moins qlq un
        IEnumerable<UserDal> GetAllBlacklister();


        //liste des utilisateurs qui sont blacklisté par qlq un en particulier 
        IEnumerable<UserDal> GetAllBlacklistedOfOneUser(int blacklisterId);


        // liste des utilisateurs qui ont blacklisté de qlq un en particulier
        IEnumerable<UserDal> GetAllBlacklisterOfOneUser(int blacklistedId);

        //est utilisateur qui est blacklister par un autre
        bool IsUser1BlacklisterOfUser2(int blacklisterId, int blacklistedId);
    }
}
