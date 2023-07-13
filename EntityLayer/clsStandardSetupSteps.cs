using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardSetupSteps : clsMain
    {
        public int id { get; set; }

        public int standardSetupId { get; set; }
        public string standardSetupStepTitle { get; set; }
        public string standardSetupStepStatus { get; set; }
    }
}
