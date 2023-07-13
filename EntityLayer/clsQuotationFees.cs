using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsQuotationFees : clsMain
    { 
        public int id { get; set; }
        public int quotationId {set;get;}
        public int quotationTypeId {set;get;}
    }
}
