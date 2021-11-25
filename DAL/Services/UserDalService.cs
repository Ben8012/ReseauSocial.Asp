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
    public class UserDalService : AbstracService, IUserDalService 
    {

        /*-------------------Post & Put & Delete----------------------------*/

        public void Register(UserDal entity)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(entity);
                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("User/register/", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public void Update(int id, UserDal entity,string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken(client, token);

                string jsonBody = JsonConvert.SerializeObject(entity);
                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PutAsync("User/" + id, content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }

        }

        public void Delete(int id, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken(client, token);

                using (HttpResponseMessage message = client.DeleteAsync("User/" + id).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }


        public void ReactivateStatus(int ChangedUserId, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken(client, token);

                using (HttpResponseMessage message = client.GetAsync("User/ReactivateStatus/"+ ChangedUserId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public void DeactivateStatus(int ChangedUserId, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken(client, token);

                using (HttpResponseMessage message = client.GetAsync("User/DeactivateStatus/" + ChangedUserId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }


        public void AskActivateStatus(int ChangedUserId, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken(client, token);

                using (HttpResponseMessage message = client.GetAsync("User/AskActivateStatus/" + ChangedUserId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public void AskDeleteStatus(int ChangedUserId, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken(client, token);

                using (HttpResponseMessage message = client.GetAsync("User/AskDeleteStatus/" + ChangedUserId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public bool EmailExists(string email)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(new { email = email });
                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("User/register/", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<bool>(json);
                }
            }
        }


        public UserDal Login(string email, string passwd)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(new LoginUserDal{ Email = email, Passwd = passwd });
                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                using (HttpResponseMessage message = client.PostAsync("User/Login", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<UserDal>(json);
                }
            }
        }

        
        public StatusDal GetStatus(int userId, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken(client, token);

                using (HttpResponseMessage message = client.GetAsync("User/GetStatus/" + userId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<StatusDal>(json);
                }
            }
        }

        #region GetUser
        /*-------------------GetUser----------------------------*/

        public UserDal GetUser(int userId, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("User/GetUser/" + userId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<UserDal>(json);
                }
            }
        }

        public IEnumerable<UserDal> GetAllUsers( string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken( client, token);

                using (HttpResponseMessage message = client.GetAsync("User/GetAllUsers/").Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<UserDal>>(json);
                }
            }
        }

        #endregion

    }

}