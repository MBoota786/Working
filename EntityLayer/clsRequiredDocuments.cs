using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsRequiredDocuments : clsMain
    { 
        public int id { get; set; }     
        public string reqDocumentName { set; get; }
        public int documentTypeId { set; get; }
        public int categoryRelationId { set; get; }
        public bool isRequired { set; get; }
        public bool isForOffice { set; get; }
        public bool isForUser { set; get; }
    }
}
