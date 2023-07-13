using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Accordia_Project.BusinessLogicLayer.General
{
    public class emailSendModel
    {
        //Send Email
        public void ResetPasswordEmailSend(string userEmail,string otpCode,string userName,string resetUrl)
        {
            try
            {
                //Get Mail Information From Database
                evolveMailNotificationDAL mailDAL = new evolveMailNotificationDAL();
                clsEvolveMailNotification mailObj = mailDAL.SelectEvolveMailNotificationByEmailType("ForgotLogin").FirstOrDefault();
                //End Mail Information

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(mailObj.notificationEmail);
                message.To.Add(new MailAddress(userEmail));
                message.Subject = mailObj.mailSubject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = PopulateFOrgotPasswordEmailBody(otpCode,userName, resetUrl);
                smtp.Port = mailObj.mailPort;
                smtp.Host = mailObj.mailSmtp; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(mailObj.notificationEmail, mailObj.mailPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Timeout = 1200000;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                smtp.Send(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //LeadUserEmail
        public void EmailSend(string userEmail, string Htmlbody,string emailType)
        {
            try
            {
                //Get Mail Information From Database
                evolveMailNotificationDAL mailDAL = new evolveMailNotificationDAL();
                clsEvolveMailNotification mailObj = mailDAL.SelectEvolveMailNotificationByEmailType(emailType).FirstOrDefault();
                //End Mail Information

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(mailObj.notificationEmail);
                message.To.Add(new MailAddress(userEmail));
                message.Subject = mailObj.mailSubject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = Htmlbody;
                smtp.Port = mailObj.mailPort;
                smtp.Host = mailObj.mailSmtp; 
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(mailObj.notificationEmail, mailObj.mailPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Timeout = 1200000;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                smtp.Send(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string PopulateWelcomeUserEmailBody(string userEmail,string userPassword, string url)
        {
            string body = string.Empty;
            body = "<!DOCTYPE html> <body><h1>Welcome To Evolve Audit Management System</h1>";
            body += "<h6>Your Login Email & Password</h6><h6>"+userEmail+"</h6><h6>"+userPassword+ "</h6><a href="+url+">Click Here For Login</a></body></html>";
            return body;
        }
        private string PopulateFOrgotPasswordEmailBody(string otpCode,string userName, string url )
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("HtmlEmailTemplate/forgotPassword.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{otpCode}", otpCode);
            body = body.Replace("{Url}", url);
           // body = body.Replace("{Description}", description);
            return body;
        }
    }
}
