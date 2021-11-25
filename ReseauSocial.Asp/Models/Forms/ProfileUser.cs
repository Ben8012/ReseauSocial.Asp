using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Models.Forms
{
    public class ProfileUser
    {
        public int Id { get; set; }

        [DisplayName("Nom")]
        public string LastName { get; set; }

        [DisplayName("Prénom")]
        public string FirstName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Status")]
        public StatusBll Status { get; set; }

    }
}
