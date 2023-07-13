using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsUserApprovalLog
    {
        public int id { get; set; }
        public string userId { get; set; }
        public bool reqApprovalSts { get; set; }
        public int approvalById { get; set; }
        public DateTime approvalDate { get; set; }
        public string remarks { get; set; }
        public int requestById { get; set; }
        public DateTime requestDate { get; set; }
        public DateTime requestTime { get; set; }

    }
}
