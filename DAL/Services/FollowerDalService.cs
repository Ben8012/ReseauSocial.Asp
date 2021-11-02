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
    public class FollowerDalService :  AbstracService, IFollowerDal
    {
        public void Follow(int followerId, int followedId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Follower/Follow/"+ followerId +"/"+ followedId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public void UnFollow(int followerId, int followedId)
        {

            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Follower/UnFollow/" + followerId + "/" + followedId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public IEnumerable<UserDal> GetAllFollowed()
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Follower/GetAllFollowed").Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<UserDal>>(json);
                }
            }
        }

        public IEnumerable<UserDal> GetAllFollowedOfOneUser(int followerId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Follower/GetAllFollowedOfOneUser/"+ followerId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<UserDal>>(json);
                }
            }
        }

        public IEnumerable<UserDal> GetAllFollower()
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Follower/GetAllFollower").Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<UserDal>>(json);
                }
            }
        }

        public IEnumerable<UserDal> GetAllFollowersOfOneUser(int followedId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Follower/GetAllFollowersOfOneUser/"+ followedId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<UserDal>>(json);
                }
            }
        }

        
    }
}
