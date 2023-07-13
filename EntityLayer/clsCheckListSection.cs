using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsCheckListSection : clsMain
    {
        public int id { get; set; }

        public int standardReqCheckListId { get; set; }
        public string checkListSectionName { get; set; }
    }
}
