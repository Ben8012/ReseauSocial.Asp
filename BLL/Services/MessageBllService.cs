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

        #region Récupération de messages
        //Récupérer tous les messages du serveurs
        public IEnumerable<MessageBll> GetAllMessages()
        {
            return _messageDal.GetAllMessages().Select(m => m.MessageDalToMessageBll());
        }


        // Récupérer tous les messages d'un utilisateur dont l'id  est userId
        public IEnumerable<MessageBll> GetAllMessagesOfUser(int userId)
        {
            return _messageDal.GetAllMessagesOfUser(userId).Select(m => m.MessageDalToMessageBll());
        }


        // Récupérer tous les messages échangés entre deux utilisateurs userId1 et userId2
        public IEnumerable<MessageBll> GetMessageBetweenToUsers(int userId1, int userId2)
        {
            return _messageDal.GetMessageBetweenToUsers(userId1, userId2).Select(m => m.MessageDalToMessageBll());
        }


        // Récupérer tous les messages envoyés par l'utilisateur userSendId à l'utilisateur userGetId
        public IEnumerable<MessageBll> GetMessageFromUser(int userSendId, int userGetId)
        {
            return _messageDal.GetMessageFromUser(userSendId, userGetId).Select(m => m.MessageDalToMessageBll());

        }

        // Récupérer un message par son Id
        public MessageBll GetMessageById(int MessageId)
        {
            return _messageDal.GetMessageById(MessageId).MessageDalToMessageBll();
        }

        #endregion

        #region Création /édition / suppression de message
        // Créer un message
        public int CreateMessage(MessageBll message)
        {
            return _messageDal.CreateMessage(message.MessageBllToMessageDal());
        }


        // Mettre à jour un message
        public void UpdateMessage(MessageBll message)
        {
            _messageDal.UpdateMessage(message.MessageBllToMessageDal());
        }


        // Supprimer un message
        public void DeleteMessage(int messageId, int userSendId)
        {
            _messageDal.DeleteMessage(messageId, userSendId);
        }

        #endregion

        #region Réception (lecture) d'un message
        // Recevoir un message (en mettant à jour la date de réception)
        public void ReciveMessage(int messageId, int userGetId)
        {
            _messageDal.ReciveMessage(messageId, userGetId);
        }

        #endregion

    }
}
