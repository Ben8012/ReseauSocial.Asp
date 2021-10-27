using BLL.Models;
using ReseauSocial.Asp.Models;
using ReseauSocial.Asp.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Mappers
{
    internal static class MapperAsp
    {
        internal static UserBll RegisterUserToUserBll(this RegisterUser entity)
        {
            return new UserBll()
            {
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,      
                Passwd = entity.Passwd,
            };
        }


        
        internal static UserAsp UserBllToUserAsp(this UserBll entity)
        {
            return new UserAsp()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                IsAdmin = entity.IsAdmin,
                Passwd = entity.Passwd,
                Status = entity.Status
            };
        }

        internal static UserBll UpdateUserToUserBll(this UpdateUser entity)
        {
            return new UserBll()
            {           
                LastName = entity.LastName,
                FirstName = entity.FirstName, 
            };
        }



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
