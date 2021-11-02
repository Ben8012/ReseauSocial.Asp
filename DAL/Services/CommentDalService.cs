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
    public class CommentDalService : AbstracService, ICommentDal
    {
   
        public IEnumerable<CommentDal> GetByArticleId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);
                using (HttpResponseMessage httpResponseMessage = client.GetAsync("Comment/GetByArticleId/" + id).Result)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<CommentDal>>(json);
                }
            }
        }

        public int CountByArticleId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);
                using (HttpResponseMessage httpResponseMessage = client.GetAsync("Comment/CountByArticleId/" + id).Result)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<int>(json);
                }
            }
        }

        public IEnumerable<CommentDal> GetByUserId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);
                using (HttpResponseMessage httpResponseMessage = client.GetAsync("Comment/GetByUserId/" + id).Result)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<CommentDal>>(json);
                }
            }
        }

        public int CountByUserId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);
                using (HttpResponseMessage httpResponseMessage = client.GetAsync("Comment/CountByUserId/" + id).Result)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<int>(json);
                }
            }
        }

        public CommentDal GetById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);
                using (HttpResponseMessage httpResponseMessage = client.GetAsync("Comment/GetById/" + id).Result)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<CommentDal>(json);
                }
            }
        }

        public int AddComment(CommentDal entity)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(new AddCommentFormDal { 
                    Message = entity.Message,
                    ArticleId = entity.ArticleId,
                    UserId = entity.UserId
                });

                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage httpResponseMessage = client.PostAsync("Comment/AddComment", content).Result)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<int>(json);
                }
            }
        }

        public IEnumerable<CommentDal> GetAllComment()
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);
                using (HttpResponseMessage httpResponseMessage = client.GetAsync("Comment/GetAllComment").Result)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<CommentDal>>(json);
                }
            }
        }
    }
}
