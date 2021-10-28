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

        public string Title { get; set; }

        public string Content { get; set; }

        public bool CommentOk { get; set; } = true;

        public bool OnLigne { get; set; } = true;

        public int UserId { get; set; }

        public DateTime Date { get; set; }

    }
}
