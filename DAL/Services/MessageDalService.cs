using DAL.Interfaces;
using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class MessageDalService : AbstracService, IMessageDal
    {
        #region Récupération de messages
        //Récupérer tous les messages du serveurs
        public IEnumerable<MessageDal> GetAllMessages()
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Message/GetAllMessages").Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<MessageDal>>(json);
                }
            }
        }

        // Récupérer tous les messages d'un utilisateur dont l'id  est userId
        public IEnumerable<MessageDal> GetAllMessagesOfUser(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Message/GetAllMessagesOfUser/" + userId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<MessageDal>>(json);
                }
            }
        }

        // Récupérer tous les messages échangés entre deux utilisateurs userId1 et userId2
        public IEnumerable<MessageDal> GetMessageBetweenToUsers(int userId1, int userId2)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(new MessageBeteweenUsersDal { UserId1 = userId1, UserId2 = userId2 });
                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                using (HttpResponseMessage message = client.PostAsync("Message/GetMessageBetweenToUsers", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<MessageDal>>(json);
                }
            }
        }


        // Récupérer tous les messages envoyés par l'utilisateur userSendId à l'utilisateur userGetId
        public IEnumerable<MessageDal> GetMessageFromUser(int UserSendId, int UserGetId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(new MessageBeteweenUsersDal { UserId1 = UserSendId, UserId2 = UserGetId });
                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                using (HttpResponseMessage message = client.PostAsync("Message/GetMessageFromUser", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<MessageDal>>(json);
                }
            }
        }

        // Récupérer un message par son Id
        public MessageDal GetMessageById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);


                using (HttpResponseMessage message = client.GetAsync("Message/GetMessageById/" + id).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<MessageDal>(json);
                }
            }
        }

        #endregion

        #region Création /édition / suppression de message
        // Créer un message
        public int CreateMessage(MessageDal entity)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(entity);
                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("Message/CreateMessage", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<int>(json);
                }
            }
        }


        // Mettre à jour un message
        public void UpdateMessage(MessageDal entity)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(entity);
                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("​Message/UpdateMessage", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }


        // Supprimer un message
        public void DeleteMessage(int messageId, int userSendId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(new DeleteMessageDal { Id = messageId, UserSend = userSendId });
                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("​Message​/DeleteMessage", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }
        #endregion

        #region Réception (lecture) d'un message

        // Recevoir un message (en mettant à jour la date de réception)
        public void ReciveMessage(int messageId, int userGetId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(new ReciveMessage { MessageId = messageId, UserGetId = userGetId });
                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                using (HttpResponseMessage message = client.PostAsync("Message/ReciveMessage", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }
        #endregion

    }
}
