using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsUserLogin : clsMain
    {
        public int  id { get; set; }
        public int  leadCompanyId { get; set; }
        public int companyId { get; set; }
        public int officeId { get; set; }
        public int designationId { get; set; }
        public string userName { get; set; }
        public string userCode { get; set; }
        public string userEmail { get; set; }
        public string userImage { get; set; }
        public DateTime? lastLogin { get; set; }
        public bool isLogin { get; set; }
        public string userPassword { get; set; }
        public string approvalStatus { get; set; }
        public int approvalBy { get; set; }
        public DateTime? approvalDate { get; set; }
        public string companyName { get; set; }
        public string loginIp { get; set; }
        public string LoginStatus { get; set; }
        public string Token { get; set; }
        public string leadStatusName { get; set; }
        public string HeadOfficeStatus { get; set; }
        public bool isAdmin { get; set; }
    }
    public class clsForgotPassword {
        public string userEmail { get; set; }
        public string changePasswordUrl { get; set; }
    }
    public class clsOTPVerification
    {
        public int id { get; set; }
        public int otpCode { get; set; }
    }
    public class clsChangePassword
    {
        public int id { get; set; }
        public string newPassword { get; set; }
    }
}
