using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Models.Forms
{
    public class RegisterUser
    {
        [Required]
        [StringLength(maximumLength:75, ErrorMessage = "Votre nom ne peut faire plus que 75 lettres !")]
        [DisplayName("Votre nom")]
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength: 75, ErrorMessage = "Votre prénom ne peut faire plus que 75 lettres !")]
        [DisplayName("Votre prénom")]
        public string FirstName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Votre email doit ressembler a  xx@xx.xx")]
        [DisplayName("Votre edresse mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Créé un mot de passe")]
        public string Passwd { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Passwd", ErrorMessage = "Le mot de passe n'est pas identique")]
        [DisplayName("Confirmer votre mot de passe")]
        public string ConfirmPasswd { get; set; }
    }
}
