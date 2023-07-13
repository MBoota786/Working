using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsEmployeeBreakDownDtl :clsMain
    {
        public int id { get; set; }
        public int employeeBreakDownMasterId { get; set; }
        public int formulaStepNo { get; set; }
        public int auditEmployeeTypeId { get; set; }
        public string formulaOperation { get; set; }
        public int empBreakDownDtlId { get; set; }
     
    }
}
