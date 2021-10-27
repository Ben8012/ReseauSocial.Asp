using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Models.Forms
{
    public class RegisterUser
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }
        public string Passwd { get; set; }
    }
}
