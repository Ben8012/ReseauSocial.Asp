using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Models.Forms
{
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        [DisplayName("Adresse mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe")]
        public string Passwd { get; set; }
    }
}
