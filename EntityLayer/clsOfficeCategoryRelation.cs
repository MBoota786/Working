using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsOfficeCategoryRelation : clsMain
    {
        public int id { get; set; }
        public int officeId { get; set; }
        public int countryId { get; set; }
        public int serviceScopeId { get; set; }
        public int hoCategoryRelationId { get; set; }
        public int relatedOfficeId { get; set; }
        public bool isRelatedWithCO { get; set; }
        public bool isRelatedWithRO { get; set; }
        public bool isOfficeDemographicScope { get; set; }
        public bool isOfficeExclusive { get; set; }

        public List<clsOfficeStandards> listOfficeStandard { get; set; }
        public List<clsOfficeCategoryRelationStandardMap> listOfficeCategoryRelStandard { get; set; }
        public List<clsOfficeCategoryStateMap> listOfficeState { get; set; }
        public List<clsOfficeCategoryCityMap> listOfficeCity { get; set; }

        public override string ToString()
        {
            return $"id: {id}, officeId: {officeId}, serviceScopeId: {serviceScopeId}, hoCategoryRelationId: {hoCategoryRelationId}, relatedOfficeId: {relatedOfficeId}, isRelatedWithCO: {isRelatedWithCO}, isOfficeDemographicScope: {isOfficeDemographicScope}";
        }
    }
}
