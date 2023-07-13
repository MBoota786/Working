using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsQuotation : clsMain
    { 
        public int id { get; set; }
        public int appId {set;get;}
        public int quotationStatusId {set;get;}
        public DateTime? quotationDate {set;get;}
        public DateTime? quotationValidityUpto {set;get;}
        public int quotationSentByUserId {set;get;}
        public int officeId {set;get;}
        public int quotationVersionId  {set;get;}
        public int quotationNo {set;get;}
        public int quotationSentTo {set;get;}
    }
}
