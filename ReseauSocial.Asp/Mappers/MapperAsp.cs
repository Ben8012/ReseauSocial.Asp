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
                Status = entity.Status,
                
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



         internal static ArticleAsp ArticleBllToArticleAsp(this ArticleBll entity)
         {
             return new ArticleAsp()
             {
                 Id = entity.Id,
                 Title = entity.Title,
                 Content = entity.Content,
                 UserId = entity.UserId,
                 CommentOk = entity.CommentOk,
                 OnLigne = entity.OnLigne,
                 Date = entity.Date
             };
         }



         internal static ArticleBll ArticleAspToArticleBll(this ArticleAsp entity)
         {
             return new ArticleBll()
             {
                 Id = entity.Id,
                 Title = entity.Title,
                 Content = entity.Content,
                 UserId = entity.UserId,
                 CommentOk = entity.CommentOk,
                 OnLigne = entity.OnLigne,
                 Date = entity.Date
             };
         }

        internal static MessageAsp MessageBllToMessageAsp(this MessageBll entity)
        {
            return new MessageAsp()
            {
                Id = entity.Id,
                Content = entity.Content,
                UserGet = entity.UserGet,
                UserSend = entity.UserSend,
                SendDate = entity.SendDate,
                RecieveDate = entity.RecieveDate
            };
        }

    }
}
