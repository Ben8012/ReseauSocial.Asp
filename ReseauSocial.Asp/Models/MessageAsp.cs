using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Asp.Models
{
    public class MessageAsp
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserSend { get; set; }
        public int UserGet { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime? RecieveDate { get; set; }

        public UserBll Sender { get; set; }
        public UserBll Reciever { get; set; }
    }
}
