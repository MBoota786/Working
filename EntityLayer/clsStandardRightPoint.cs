using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardRightPoint : clsMain
    { 
        public int id { get; set; }
        public string standardRightPoint { get; set; }
        public override string ToString()
        {
            return $"id: {id}, standardRightPoint: {standardRightPoint}";
        }
    }
}
