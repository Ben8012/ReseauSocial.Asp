using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMessageDal
    {
        void CreateMessage(MessageDal message);
        void DeleteMessage(MessageDal message);
        IEnumerable<MessageDal> GetMessageBetweenToUsers(int UserId1, int UserId2);
        MessageDal GetMessageById(int MessageId);
        IEnumerable<MessageDal> GetMessageFromUser(int UserSendId, int UserGetId);
        void ReciveMessage(int messageId, int UserGetId);
        void UpdateMessage(MessageDal message);
    }
}
