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
        public string messageText { get; set; }
        public int appId { get; set; }
        public int applicationReviewId { get; set; }
        public bool isReceiver { get; set; }
        public bool isSender { get; set; }
        public int isDelete { get; set; }
        public DateTime? reminder { get; set; }
        public DateTime timeStamp { get; set; }
         
    }
}
