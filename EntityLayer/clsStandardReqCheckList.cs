using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardReqCheckList : clsMain
    {
        public int id { get; set; }
        public int accreditationBodyStandardId { get; set; }
        public int checkListTypeId { get; set; }
        public bool isRequired { get; set; }
        public int auditTypeId { get; set; }
        public bool docUploadRequired { get; set; }
        public string auditCheckListPath { get; set; }
    }
}
