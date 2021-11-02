using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.HubTools
{
    public class CommentHub : Hub, ICommentHub
    {
        private readonly ICommentBll _commentService;
        private readonly IUserBllService _userService;
        public CommentHub(ICommentBll commentService, IUserBllService userService) : base()
        {
            _commentService = commentService;
            _userService = userService;
        }
        public async Task SendComment(string message, int articleId, int userId)
        {
            _commentService.AddComment(new CommentBll
            {
                Message = message,
                ArticleId = articleId,
                UserId = userId
            });
            UserBll user = _userService.GetUser(userId);
            await Clients.All.SendAsync("ReceiveComment", message, userId, user.LastName + " " + user.FirstName);
        }
        public async Task GetComments(int articleId)
        {
            IEnumerable<object> comments = _commentService.GetByArticleId(articleId)
                .OrderByDescending(c => c.Date)
                .Select(c => new
                {
                    Message = c.Message,
                    UserId = c.UserId,
                    Date = c.Date,
                    AuthorName = _userService.GetUser(c.UserId).LastName + " " + _userService.GetUser(c.UserId).FirstName
                });
            await Clients.Caller.SendAsync("ReceiveComments", JsonConvert.SerializeObject(comments));
        }
    }
}
