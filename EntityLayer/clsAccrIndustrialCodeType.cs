using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccrIndustrialCodeType : clsMain
    { 
        public int id { get; set; }
        public string accrIndustrialCodeType { get; set; }
        public DateTime applicableFromDate { get; set; }
        public List<List<object>> listExcel { get; set; }
        public int officeId { get; set; }
    }
    public class listExcel
    {
        public string section { get; set; }
        public string sectionTitle { get; set; }
        public string division { get; set; }
        public string divisionTitle { get; set; }
        public string group  { get; set; }
        public string groupTitle  { get; set; }
        public string groupDescription  { get; set; }
        public string className { get; set; }
        public string classTitle { get; set; }
        public string classDescription { get; set; }
    }
}
