using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsOfficeType : clsMain
    {
        public int id  { get; set; }
        public string officeTypeName { get; set; }
        public string officeTypeAlias { get; set; }
        public string officeTypePrefix { get; set; }
        public int initialOfficeTypeCount { get; set; }
    }
}
