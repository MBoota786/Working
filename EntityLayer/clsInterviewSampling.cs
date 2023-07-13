using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsInterviewSampling : clsMain
    {
        public int id { get; set; }
        public int standardSetupId { get; set; }
        public int employeeStartRange { get; set; }
        public int employeeEndRange { get; set; }
        public int individualInterviews { get; set; }
        public int groupInterviews { get; set; }
        public int estimatedTimeInMinutes { get; set; }
        public int totalRecordedViews { get; set; }
    }
}
