using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppReviewerComments : clsMain
    { 
        public int id { get; set; }
        public int applicationReviewId { set;get;}
        public int auditApplicationReviewPointId { set;get;}
        public string reviewPointComment { set;get;}
        public int reviewPointStatusId { set;get;}
        public string reviewPoint { get; set; }
    }
}
