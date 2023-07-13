using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsCompany : clsMain
    {
        public int id { get; set; }
        public string code { get; set; }
        public string companyName { get; set; }
        public string companyAddress { get; set; }
        public int countryId { get; set; }
        public int stateProviceId { get; set; }
        public int cityId { get; set; }
        public string postalCode { get; set; }
        public string companyWebsite { get; set; }
        public string companyCellNo { get; set; }
        public string companyPhone { get; set; }
        public int leadCompanyId { get; set; }
        public string encrPassword { get; set; }
        public string folderPath { get; set; }
        public List<int> listStandard { get; set; }
    }
}
