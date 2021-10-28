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
    public class MessageBllService : IMessageBll
    {

        private readonly IMessageDal _messageDal;

        public MessageBllService(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void CreateMessage(MessageBll message)
        {
            _messageDal.CreateMessage(message.MessageBllToMessageDal());
        }

        public void DeleteMessage(int messageId, int userSendId)
        {
            _messageDal.DeleteMessage( messageId, userSendId);
        }

        public IEnumerable<MessageBll> GetMessageBetweenToUsers(int UserId1, int UserId2)
        {
            return _messageDal.GetMessageBetweenToUsers(UserId1, UserId2).Select(m => m.MessageDalToMessageBll());
        }

        public MessageBll GetMessageById(int MessageId)
        {
            return _messageDal.GetMessageById(MessageId).MessageDalToMessageBll();
        }

        public IEnumerable<MessageBll> GetMessageFromUser(int UserSendId, int UserGetId)
        {
            return _messageDal.GetMessageFromUser(UserSendId, UserGetId).Select(m => m.MessageDalToMessageBll());

        }

        public void ReciveMessage(int messageId, int UserGetId)
        {
            _messageDal.ReciveMessage(messageId, UserGetId);
        }

        public void UpdateMessage(MessageBll message)
        {
            _messageDal.UpdateMessage(message.MessageBllToMessageDal());
        }
    }
}
