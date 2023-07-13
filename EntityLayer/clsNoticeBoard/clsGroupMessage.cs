using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.clsNoticeBoard
{
    class clsGroupMessage
    {
        public int id { get; set; }
        public int senderId { get; set; }
        public int groupId { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }
        public bool isReaded { get; set; }
        public bool isSender { get; set; }
        public bool isReceiver { get; set; }
    }
}
