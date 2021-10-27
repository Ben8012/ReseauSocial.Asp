using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public abstract class AbstracService
    {
        protected void setBaseAdress(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44392/api/");
        } 
        
    }
}
