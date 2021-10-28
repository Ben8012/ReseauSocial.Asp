using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Models.Forms
{
    public class ArticleForm
    {
        [DisplayName("Titre")]
        [Required]
        public string Title { get; set; }

        [DisplayName("Contenu")]
        [Required]
        public string Content { get; set; }

        [DisplayName("Activer les commentaire")]
        [Required]
        public bool CommentOk { get; set; } = true;

        [DisplayName("Mettre en ligne")]
        [Required]
        public bool OnLigne { get; set; } = true;
    
    }
}
