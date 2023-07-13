using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsSetupSteps
    {
        public int id { get; set; }
        public string stepName { get; set; }
        public string stepLink { get; set; }
        public int parentStepId { get; set; }

        public List<clsSetupSteps> childSteps { get; set; }
    }
}
