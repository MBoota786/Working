using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsOfficeScope : clsMain
    { 
        public int id { get; set; }
        public int officeId { get; set; }
        public int countryId { get; set; }
        public int serviceScopeId { get; set; }
        public bool isExclusive { get; set; }
        public List<clsOfficeScopeStandardMap> scopeStandard { get; set; }
        public List<clsOfficeScopeStateMap> scopeState { get; set; }
        public List<clsOfficeScopeCityMap> scopeCity { get; set; }
        public override string ToString()
        {
            return $"id: {id}, officeId: {officeId}, countryId: {countryId}, serviceScopeId: {serviceScopeId}";
        }
    }
}
