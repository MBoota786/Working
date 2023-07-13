using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsOfficeDocumentDtl : clsMain
    {
        public int  id { get; set; }
        public int officeDocumentMasterId { get; set; }
        public bool isExpiry { get; set; }
        public DateTime expiryDate { get; set; }
        public string documentSrNo { get; set; }
        public string documentPath { get; set; }
        public DateTime documentDate { get; set; }
        public string documentFileName { get; set; }
    }
}
