using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsEvolveMailNotification : clsMain
    { 
        public int id { get; set; }
        public int evolveMailTypeId { set;get;}
        public string evolveMailType { set;get;}
        public string notificationEmail { set;get;}
        public string mailPassword { set;get;}
        public int mailPort { set;get;}
        public string mailSmtp { set;get;}
        public string mailSubject { set;get;}
        
    }
}
