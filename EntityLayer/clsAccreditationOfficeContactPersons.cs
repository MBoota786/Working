using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccreditationOfficeContactPersons : clsMain
    { 
        public int id { get; set; }
        public int accreditationId{set;get;}
        public int contactPersonCategoryId{set;get;}
        public string salutationName {set;get;}
        public string firstName {set;get;}
        public string middleName {set;get;}
        public string lastName {set;get;}
        public int designationId {set;get;}
        public string contactPersonEmail {set;get;}
        public string contactPersonPhone {set;get;}
        public string contactPersonCellNo { set; get; }
        public string otherContactPersonCategory { set; get; }
        public string contactPersonPhoneIsoCode { set; get; }
        public string contactPersonCellNoIsoCode { set; get; }
        public string contactPersonPhoneExt { set; get; }
    }
}
