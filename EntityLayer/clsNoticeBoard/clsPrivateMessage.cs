using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.clsNoticeBoard
{
    public class clsPrivateMessage
    {
        public int id { get; set; }
        public int senderId { get; set; }
        public int receiverId { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }
        public bool isReaded { get; set; }
        public bool isSender { get; set; }
        public bool isReceiver { get; set; }
    }
}
