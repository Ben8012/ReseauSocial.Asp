using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMessageBll
    {
        int CreateMessage(MessageBll message);
        void DeleteMessage(int messageId, int userSendId);
        IEnumerable<MessageBll> GetMessageBetweenToUsers(int UserId1, int UserId2);
        MessageBll GetMessageById(int MessageId);
        IEnumerable<MessageBll> GetMessageFromUser(int UserSendId, int UserGetId);
        void ReciveMessage(int messageId, int UserGetId);
        void UpdateMessage(MessageBll message);
    }
}
