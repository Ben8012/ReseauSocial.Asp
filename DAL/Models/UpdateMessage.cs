using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UpdateMessage
    {
        public int Id { get; set; }
        public int UserSend { get; set; }
        public string Content { get; set; }
    }
}
