using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserDal
    {
        public int Id { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }
        public string Passwd { get; set; }
        public string Token { get; set; }

    }
}
