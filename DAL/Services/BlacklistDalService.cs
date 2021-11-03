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
    public class BlacklistDalService : AbstracService, IBlacklistDal
    {
        public void Blacklist(int blacklisterId, int blacklistedId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Blacklist/Blacklist/" + blacklisterId + "/" + blacklistedId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public void UnBlacklist(int blacklisterId, int blacklistedId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Blacklist/UnBlacklist/" + blacklisterId + "/" + blacklistedId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public IEnumerable<UserDal> GetAllBlacklisted()
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Blacklist/GetAllBlacklisted").Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<UserDal>>(json);
                }
            }
        }

        public IEnumerable<UserDal> GetAllBlacklistedOfOneUser(int blacklisterId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Blacklist/GetAllBlacklistedOfOneUser/"+ blacklisterId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<UserDal>>(json);
                }
            }
        }

        public IEnumerable<UserDal> GetAllBlacklister()
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Blacklist/GetAllBlacklister").Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<UserDal>>(json);
                }
            }
        }

        public IEnumerable<UserDal> GetAllBlacklisterOfOneUser(int blacklistedId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Blacklist/GetAllBlacklisterOfOneUser/" + blacklistedId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<UserDal>>(json);
                }
            }
        }

        public bool IsUser1BlacklisterOfUser2(int blacklisterId, int blacklistedId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Blacklist/IsUser1BlacklisterOfUser2/" + blacklisterId +"/"+ blacklistedId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<bool>(json);
                }
            }
        }

       
    }
}
