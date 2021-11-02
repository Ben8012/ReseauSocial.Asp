using System.Threading.Tasks;

namespace ReseauSocial.Asp.HubTools
{
    public interface ICommentHub
    {
        Task GetComments(int articleId);
        Task SendComment(string message, int articleId, int userId);
    }
}