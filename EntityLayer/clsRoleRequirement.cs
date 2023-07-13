using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsRoleRequirement : clsMain
    { 
        public int id { get; set; }
        public int accreditationBodyId { get; set; }
        public int roleId { get; set; }
        public string requirementName { get; set; }
        public bool isDocumentUploadRequired { get; set; }
        public string roleName { get; set; }
        public string accreditationName { get; set; }
    }
}
