using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBlacklistBll
    {
        void Blacklist(int blacklisterId, int blacklistedId);


        void UnBlacklist(int blacklisterId, int blacklistedId);


        // liste de tout les utilisateur qui sont blacklister au moins par qlq un 
        IEnumerable<UserBll> GetAllBlacklisted();


        //liste de tout les utilisateurs qui ont blacklister au moins qlq un
        IEnumerable<UserBll> GetAllBlacklister();


        //liste des utilisateurs qui sont blacklisté par qlq un en particulier 
        IEnumerable<UserBll> GetAllBlacklistedOfOneUser(int blacklisterId);


        // liste des utilisateurs qui ont blacklisté de qlq un en particulier
        IEnumerable<UserBll> GetAllBlacklisterOfOneUser(int blacklistedId);

        //est utilisateur qui est blacklister par un autre
        bool IsUser1BlacklisterOfUser2(int blacklisterId, int blacklistedId);
    }
}
