using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Models.Forms
{
    public class Comment
    {
        public ArticleBll Article { get; set; }
        public string Message { get; set; }
    }
}
