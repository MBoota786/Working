using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsOfficeDocumentMaster : clsMain
    {
        public int  id { get; set; }
        public int officeIdOrUserId { get; set; }
        public int requiredDocumentId { get; set; }
        public int documentTypeId { get; set; }
        public int officeDocumentCategoryId { get; set; }
        public string officeDocumentTitle { get; set; }
        
    }
}
