using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsOfficeDocumentUpload : clsMain
    {
       
        public int companyId { get; set; }
        public int officeId { set;get;}
        public int documentMasterId { set;get;}
        public int documentDtlId { set;get;}
        public byte[] fileByte { set;get;}
        public string folderTitle { set;get;}
        public string documentTitleWithExtension { set;get;}
    
    }
}
