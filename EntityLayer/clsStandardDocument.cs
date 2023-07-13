using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardDocument : clsMain
    {
        public int id { get; set; }
        public int standardSetupId { get; set; }
        public string standardDocumentType { get; set; }
        public string standardDocumentTitle { get; set; }
        public string standardDocumentPath { get; set; }
    }
}
