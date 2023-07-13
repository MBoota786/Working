using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsApplicationReview : clsMain
    { 
        public int id { get; set; }
        public int reviewerId { set;get;}
        public DateTime? reviewStartDate { set;get;}
        public DateTime? reviewEndDate { set;get;}
        public string reviewRiskConsider { get; set; }
        public int finalDecisionId { get; set; }
        public List<clsAppReviewerComments> appReviewerComments { get; set; }
        public int appId { get; set; }
        public string signImgPath { get; set; }
    }
}
