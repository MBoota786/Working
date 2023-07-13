using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardRights : clsMain
    { 
        public int id { get; set; }
        public int officeId { get; set; }
        public int accreditationStandardId { get; set; }
        public int standardRightPointId { get; set; }
        public string standardRightPoint { get; set; }
        public override string ToString()
        {
            return $"id: {id}, officeId: {officeId}, accreditationStandardId: {accreditationStandardId}, standardRightPointId: {standardRightPointId}";
        }
    }
}
