using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    [Serializable()]
  public  class ClsRegister
    {
        public int UId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public bool Standard1 { get; set; }
        public bool Standard2 { get; set; }
        public bool Standard3 { get; set; }
        public bool Standard4 { get; set; }
        public string DBName { get; set; }
        public string LoginStatus { get; set; }
        public string Token { get; set; }
    }
}
