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
                Token = entity.Token,
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


         internal static ArticleDal ArticleBllToArticleDal(this ArticleBll entity)
         {
             return new ArticleDal()
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
                 Date = entity.Date
             };
         }

        #region Message
        internal static MessageDal MessageBllToMessageDal(this MessageBll entity)
        {
            return new MessageDal()
            {
                Id = entity.Id,
                Content = entity.Content,
                UserSend = entity.UserSend,
                UserGet = entity.UserGet,
                SendDate = entity.SendDate,
                RecieveDate = entity.RecieveDate,
            };
        }



        internal static MessageBll MessageDalToMessageBll(this MessageDal entity)
        {
            return new MessageBll()
            {
                Id = entity.Id,
                Content = entity.Content,
                UserSend = entity.UserSend,
                UserGet = entity.UserGet,
                SendDate = entity.SendDate,
                RecieveDate = entity.RecieveDate,
            };
        }
        #endregion

        #region Comment
        internal static CommentBll CommentDalToCommentBll(this CommentDal entity)
        {
            return new CommentBll()
            {
                Id = entity.Id,
                ArticleId = entity.ArticleId,
                UserId = entity.UserId,
                Message = entity.Message,
                Date = entity.Date

            };
        }

        internal static CommentDal CommentBllToCommentDal(this CommentBll entity)
        {
            return new CommentDal()
            {
                Id = entity.Id,
                ArticleId = entity.ArticleId,
                UserId = entity.UserId,
                Message = entity.Message,
                Date = entity.Date

            };
        }
        #endregion
    }
}