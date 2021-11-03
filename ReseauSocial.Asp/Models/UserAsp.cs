using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Models
{
    public class UserAsp
    {
        public int Id { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
        public string Passwd { get; set; }

        public StatusBll Status { get; set; }

        public string Token { get; set; }
    }
}
