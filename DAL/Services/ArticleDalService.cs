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
    public class ArticleDalService : AbstracService, IArticleDal
    {
        public void BlockArticle(int articleId, int adminId, string messageWhyBlocked)
        {

            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(
                    new ArticleBlocked {
                        ArticleId = articleId,
                        AdminId = adminId,
                        Message = messageWhyBlocked 
                    });
                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("Article/BlockArticle", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public void CommentArticle(int articleId, int userId, string messageComment)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(
                    new CommentArticle {
                        ArticleId = articleId,
                        UserId = userId,
                        Message = messageComment 
                    });

                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("Article/CommentArticle", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public void Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.DeleteAsync("Article/Delete/" + id).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public IEnumerable<ArticleDal> GetAllArticle()
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Article/GetAllArticle").Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<ArticleDal>>(json);
                }
            }
        }

        public ArticleDal GetArticleById(int articleId)
        {

            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);
               
                using (HttpResponseMessage message = client.GetAsync("Article/GetArticleById/" + articleId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<ArticleDal>(json);
                }
            }
        }

        public IEnumerable<ArticleDal> GetArticleByUserId(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Article/GetArticleByUserId/" + userId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<ArticleDal>>(json);
                }
            }
        }

        public void Insert(ArticleDal article)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(article);
                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("Article/Insert", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public void SignalArticle(int articleId, int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(
                    new SignalArticle { 
                        ArticleId = articleId,
                        UserId = userId
                    });

                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("Article/SignalArticle", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public void Update(int id, ArticleDal article)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(
                    new ArticleDal {
                        Id = id,
                        Title = article.Title,
                        Content = article.Content,
                        CommentOk = article.CommentOk,
                        OnLigne = article.OnLigne,
                        UserId = article.UserId
                    });

                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("Article/Update/"+id, content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }
    }
}
