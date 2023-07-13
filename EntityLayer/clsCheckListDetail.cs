using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsCheckListDetail :clsMain
    {
        public int id { get; set; }

        public int checkListSectionId { get; set; }
        public string checkListDetails { get; set; }
    }
}
