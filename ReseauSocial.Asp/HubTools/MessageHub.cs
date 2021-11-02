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
            /*await Clients.All.SendAsync("ReceiveMessage", JsonConvert.SerializeObject(message));*/

            //envois des touts messages entre 2 utilisateurs 
            await Clients.All.SendAsync("MessageBetweenToUsers", GetMessageBetweenToUsersJson(userSend, userGet), userSend, userGet);

            //envois de la liste des contacts a l'envoyeur du message
            await GetListContact(userSend);

            //envois de la liste des contacts au receveur du message
            await GetListContact(userGet);
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

            await Clients.Caller.SendAsync("MessageBetweenToUsers", JsonConvert.SerializeObject(listMessages), userId1, userId2);
            await GetListContact(userId1);
        }


        public async Task GetAllUsers(int curentUserId)
        {
            IEnumerable<UserBll> listUsers = _userService.GetAllUsers()
                .Where(u => u.Id != curentUserId)
                .OrderBy(u => u.LastName);
                
            await Clients.Caller.SendAsync("ReceiveListUsers", JsonConvert.SerializeObject(listUsers), curentUserId);
        }

        public async Task GetListContact(int curentUserId)
        {
            IEnumerable<Contact> listContact = _messageService.GetAllMessagesOfUser(curentUserId)
                .Select(m => m.UserSend != curentUserId ? m.UserSend : m.UserGet)
                .Distinct()
                .Select(id => _userService.GetUser(id))
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
                }).OrderByDescending(c => c.CountMessageNotRead); ;

            await Clients.All.SendAsync("ReceiveListContact", JsonConvert.SerializeObject(listContact),curentUserId);
        }

        private string GetMessageBetweenToUsersJson(int userId1, int userId2)
        {
            IEnumerable<MessageBll> listMessagesBll = _messageService.GetMessageBetweenToUsers(userId1, userId2);
            foreach (int idMessage in listMessagesBll.Where(m => m.RecieveDate is null && m.UserGet == userId1).Select(m => m.Id))
            {
                _messageService.ReciveMessage(idMessage, userId1);
            }

            IEnumerable<MessageAsp> listMessages = _messageService.GetMessageBetweenToUsers(userId1, userId2).Select(m =>
            {
                MessageAsp message = m.MessageBllToMessageAsp();
                message.Sender = _userService.GetUser(message.UserSend);
                message.Reciever = _userService.GetUser(message.UserGet);
                return message;
            });

             return JsonConvert.SerializeObject(listMessages);
            
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