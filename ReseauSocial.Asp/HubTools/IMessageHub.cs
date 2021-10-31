using System.Threading.Tasks;

namespace ReseauSocial.Asp.HubTools
{
    public interface IMessageHub
    {
        Task GetMessageBetweenToUsers(int userId1, int userId2);
        Task SendMessage(int userSend, int userGet, string content);
    }
}