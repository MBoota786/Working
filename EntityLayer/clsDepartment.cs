using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsDepartment : clsMain
    { 
        public int id { get; set; }
        public string departmentName { get; set; }
        public int parentDepartmentId { get; set; }
    }
}
