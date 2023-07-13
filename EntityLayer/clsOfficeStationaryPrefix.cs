using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsOfficeStationaryPrefix : clsMain
    { 
        public int id { get; set; }
        public int officeId { get; set; }
        public int stationaryTypeId { get; set; }
        public string officeStationaryPrefix  { get; set; }
        public int startFrom  { get; set; }
        public int incrementNo  { get; set; }
        public int maxNumber  { get; set; }
    }
}
