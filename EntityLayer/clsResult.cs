using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsResult 
    {
        public int id { get; set; }
        public List<object> Data { get; set; }
        public string error { get; set; }
        public string message { get; set; }
        public bool isSuccess { get; set; }
    }
}
