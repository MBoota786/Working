using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAnnouncementType : clsMain
    {
        public int id { get; set; }
        public string announcementTypeName { get; set; }
        public bool isTimeRequired { get; set; }
        public bool isDateRequired { get; set; }
    }
}
