using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsCheckList : clsMain
    {
        public int id { get; set; }

        public int standardReqCheckListId { get; set; }
        public int checkListSectionId { get; set; }
        public string checkPointName { get; set; }
    }
}
