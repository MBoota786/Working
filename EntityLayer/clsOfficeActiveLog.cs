using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsOfficeActiveLog 
    {
        public int id { get; set; }
        public int officeId { get; set; }
        public bool reqActiveSts { get; set; }
        public int approvalById { get; set; }
        public DateTime approvalDate { get; set; }
        public string remarks { get; set; }
        public int requestById { get; set; }
        public DateTime requestDate { get; set; }
        public DateTime requestTime { get; set; }
        public string requestRemarks { get; set; }
        public string officeName { get; set; }
    }
}
