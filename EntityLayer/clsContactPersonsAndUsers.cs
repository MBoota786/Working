using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsContactPersonsUsers : clsMain
    {
        public int  id { get; set; }
        public int contactTypeId { get; set; }
        public int officeId { get; set; }
        public string salutationName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string contactPersonEmail { get; set; }
        public string contactPersonPhone { get; set; }
        public string contactPersonCellNo { get; set; }

        public int designationId { get; set; }
        public bool isAccessAllowed { get; set; }
        public int userContactPersonId { get; set; }
        public string userPassword { get; set; }
        public string approvalStatus { get; set; }
        public int approvalBy { get; set; }
        public DateTime approvalDate { get; set; }

        public string designationName { get; set; }
        public string cellNoIsoCode { get; set; }
        public string contactPersonPhoneExt { get; set; }
        public List<clsRole> roleList { get; set; }
    }
}
