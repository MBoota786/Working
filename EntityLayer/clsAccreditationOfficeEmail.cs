using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsAccreditationOfficeEmail : clsMain
    {
        public int id { get; set; }
        public int accreditationId {set;get;}
        public string officeEmailAddress { set; get; }
    }
}
