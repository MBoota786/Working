using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsUserRoleRequirement : clsMain
    { 
        public int id { get; set; }
        public int userLoginId { get; set; }     
        public int roleId { get; set; }     
        public int roleRequirementId { get; set; }     
        public string roleRequirementText { get; set; }     
        public string roleRequirementDocPath { get; set; }     
        public string userRequirementStatus { get; set; }
        public string roleName { get; set; }
        public string userName { get; set; }
    }
}
