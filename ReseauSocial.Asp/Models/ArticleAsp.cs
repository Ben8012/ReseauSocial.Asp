using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Models
{
    public class ArticleAsp
    {
 
        public int Id { get; set; }

        [DisplayName("Titre")]
        public string Title { get; set; }

        [DisplayName("Contenu")]
        public string Content { get; set; }

        [DisplayName("Activez les commentaires")]
        public bool CommentOk { get; set; } = true;

        [DisplayName("Mettre en ligne")]
        public bool OnLigne { get; set; } = true;

        [DisplayName("Créé par ")]
        public int UserId { get; set; }

        [DisplayName("Date de création")]
        public DateTime Date { get; set; }

        public UserAsp UserArticle { get; set; }

        public StatusArticleEnum StatusArticle { get; set; }

    }
}
