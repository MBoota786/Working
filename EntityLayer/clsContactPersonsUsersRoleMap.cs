using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsContactPersonsUsersRoleMap : clsMain
    { 
        public int id { get; set; }
        public int contactPersonsUsersId { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
    }
}
