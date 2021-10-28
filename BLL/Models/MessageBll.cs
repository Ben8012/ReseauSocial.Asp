using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MessageBll
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserSend { get; set; }
        public int UserGet { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime? RecieveDate { get; set; }
    }
}
