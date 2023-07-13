using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsUserRoleMap : clsMain
    { 
        public int id { get; set; }
        public int userLoginId { get; set; }
        public int roleId { get; set; }
        public string roleApprovalStatus { get; set; }
        public string roleName { get; set; }
       
    }
}
