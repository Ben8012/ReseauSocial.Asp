using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReseauSocial.Asp.Mappers;
using ReseauSocial.Asp.Models;

namespace ReseauSocial.Asp.HubTools
{
    public class MessageHub : Hub, IMessageHub
    {
        private readonly IMessageBll _messageService;
        private readonly IUserBllService _userService;

        public MessageHub(IMessageBll messageService, IUserBllService userService) : base()
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task SendMessage(int userSend, int userGet, string content)
        {
            int messageId = _messageService.CreateMessage(new MessageBll
            {
                UserSend = userSend,
                UserGet = userGet,
                Content = content
            });

            MessageAsp message = _messageService.GetMessageById(messageId).MessageBllToMessageAsp();
            message.Sender = _userService.GetUser(message.UserSend);
            message.Reciever = _userService.GetUser(message.UserGet);
            await Clients.All.SendAsync("ReceiveMessage", JsonConvert.SerializeObject(message));
        }

        public async Task GetMessageBetweenToUsers(int userId1, int userId2)
        {
            IEnumerable<MessageBll> listMessagesBll = _messageService.GetMessageBetweenToUsers(userId1, userId2);
            foreach (int idMessage in listMessagesBll.Where(m => m.RecieveDate is null && m.UserGet == userId1).Select(m => m.Id))
            {
                _messageService.ReciveMessage(idMessage, userId1);
            }

            IEnumerable <MessageAsp> listMessages = _messageService.GetMessageBetweenToUsers(userId1, userId2).Select(m =>
            {
                MessageAsp message = m.MessageBllToMessageAsp();
                message.Sender = _userService.GetUser(message.UserSend);
                message.Reciever = _userService.GetUser(message.UserGet);
                return message;
            });

            await Clients.Caller.SendAsync("MessageBetweenToUsers", JsonConvert.SerializeObject(listMessages));
            await GetListContact(userId1);
        }




        public async Task GetListContact(int curentUserId)
        {
            IEnumerable<Contact> listContact = _userService.GetAllUsers()
                .Where(u => u.Id != curentUserId)
                .Select(u =>
                {
                    return new Contact
                    {
                        Id = u.Id,
                        LastName = u.LastName,
                        FirstName = u.FirstName,
                        Email = u.Email,
                        CountMessageNotRead = _messageService.GetMessageFromUser(u.Id, curentUserId)
                            .Count(m => m.RecieveDate is null),
                        LastMessage = _messageService.GetMessageBetweenToUsers(u.Id, curentUserId)
                            .OrderByDescending(m => m.SendDate)
                            .FirstOrDefault()
                    };
                }).OrderByDescending(c => c.CountMessageNotRead);
            await Clients.Caller.SendAsync("ReceiveListContact", JsonConvert.SerializeObject(listContact));
        }
    }
}

/*CreateMessage(MessageBll message);
public int Id { get; set; }
public string Content { get; set; }
public int UserSend { get; set; }
public int UserGet { get; set; }
public DateTime SendDate { get; set; }
public DateTime? RecieveDate { get; set; }*/