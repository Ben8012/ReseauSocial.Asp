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
        #region Récupération de messages
        //Récupérer tous les messages du serveurs
        IEnumerable<MessageDal> GetAllMessages();

        // Récupérer tous les messages d'un utilisateur dont l'id  est userId
        IEnumerable<MessageDal> GetAllMessagesOfUser(int userId);

        // Récupérer tous les messages échangés entre deux utilisateurs userId1 et userId2
        IEnumerable<MessageDal> GetMessageBetweenToUsers(int UserId1, int UserId2);

        // Récupérer tous les messages envoyés par l'utilisateur userSendId à l'utilisateur userGetId
        IEnumerable<MessageDal> GetMessageFromUser(int userSendId, int userGetId);

        // Récupérer un message par son Id
        MessageDal GetMessageById(int MessageId);
        #endregion

        #region Création /édition / suppression de message
        // Créer un message
        int CreateMessage(MessageDal message);

        // Mettre à jour un message
        void UpdateMessage(MessageDal message);

        // Supprimer un message
        void DeleteMessage(int messageId, int userSendId);
        #endregion

        #region Réception (lecture) d'un message
        // Recevoir un message (en mettant à jour la date de réception)
        void ReciveMessage(int messageId, int userGetId);
        #endregion
    }
}
