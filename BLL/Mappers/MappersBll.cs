using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    internal static class MappersBll
    {
        internal static UserDal UserBllToUserDal(this UserBll entity)
        {
            return new UserDal()
            {
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                IsAdmin = entity.IsAdmin,
                Passwd = entity.Passwd,
            };
        }



        internal static UserBll DalUserToBllUser(this UserDal entity)
        {
            return new UserBll()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                IsAdmin = entity.IsAdmin,
                Passwd = entity.Passwd,
            };
        }


        #region Status

        /*--------Status--------*/
        internal static StatusBll DalStatusToBllStatus(this StatusDal entity)
        {
            return new StatusBll()
            {
                Id = entity.Id,
                Name = entity.Name 
            };
        }
        #endregion


        /* internal static ArticleDal ArticleBllToArticleDal(this ArticleBll entity)
         {
             return new ArticleDal()
             {
                 Id = entity.Id,
                 Title = entity.Title,
                 Content = entity.Content,
                 UserId = entity.UserId,
                 CommentOk = entity.CommentOk,
                 OnLigne = entity.OnLigne,
             };
         }



         internal static ArticleBll ArticleDalToArticleBll(this ArticleDal entity)
         {
             return new ArticleBll()
             {
                 Id = entity.Id,
                 Title = entity.Title,
                 Content = entity.Content,
                 UserId = entity.UserId,
                 CommentOk = entity.CommentOk,
                 OnLigne = entity.OnLigne,
             };
         }*/
    }
}
