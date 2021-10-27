using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Models
{
    public class UserSession
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
