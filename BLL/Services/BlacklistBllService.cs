using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using BLL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BlacklistBllService : IBlacklistBll
    {
        private readonly IBlacklistDal _blacklistDal;

        public BlacklistBllService(IBlacklistDal blacklistDal)
        {
            _blacklistDal = blacklistDal;
        }

        public void Blacklist(int blacklisterId, int blacklistedId)
        {
            _blacklistDal.Blacklist(blacklisterId, blacklistedId);
        }

        public IEnumerable<UserBll> GetAllBlacklisted()
        {
            return _blacklistDal.GetAllBlacklisted().Select(u => u.DalUserToBllUser());
        }

        public IEnumerable<UserBll> GetAllBlacklistedOfOneUser(int blacklisterId)
        {
            return _blacklistDal.GetAllBlacklistedOfOneUser( blacklisterId).Select(u => u.DalUserToBllUser());
        }

        public IEnumerable<UserBll> GetAllBlacklister()
        {
            return _blacklistDal.GetAllBlacklister().Select(u => u.DalUserToBllUser());
        }

        public IEnumerable<UserBll> GetAllBlacklisterOfOneUser(int blacklistedId)
        {
            return _blacklistDal.GetAllBlacklisterOfOneUser( blacklistedId).Select(u => u.DalUserToBllUser());
        }

        public bool IsUser1BlacklisterOfUser2(int blacklisterId, int blacklistedId)
        {
            return _blacklistDal.IsUser1BlacklisterOfUser2(blacklisterId, blacklistedId);
        }

        public void UnBlacklist(int blacklisterId, int blacklistedId)
        {
            _blacklistDal.UnBlacklist(blacklisterId, blacklistedId);
        }
    }
}
