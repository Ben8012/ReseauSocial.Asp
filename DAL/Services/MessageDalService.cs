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
        public void CreateMessage(MessageDal entity)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(entity);
                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("Message/CreateMessage", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public void DeleteMessage(int messageId , int userSendId )
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

        public MessageDal GetMessageById(int MessageId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);


                using (HttpResponseMessage message = client.GetAsync("Message/GetMessageById/" + MessageId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<MessageDal> (json);
                }
            }
        }

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

        public void ReciveMessage(int messageId, int userGetId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(new ReciveMessage { MessageId = messageId, UserGetId = userGetId });
                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("​Message/ReciveMessage", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

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
    }
}
