using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsOfficeSetupSteps  : clsMain
    {
        public int id { get; set; }

        public int stepId { get; set; }
        public int stepStatusId { get; set; }
        public int officeId { get; set; }
        public DateTime stepDate { get; set; }
        public DateTime stepTime { get; set; }
        public string stepName { get; set; }
        public string stepStatusName { get; set; }
    }
}
