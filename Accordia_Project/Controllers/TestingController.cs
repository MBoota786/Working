using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using System.Threading;
using Google.Apis.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        // GET: api/<TestingController>
        //[HttpGet]
        //public List<object> Get()
        //{
        //    SQLDataAccess sd = new SQLDataAccess();
        //    return sd.DapperGetCmd("spSelectAllOfficeTaxDetail", "");
        //     //lst;
        //}

        //// GET api/<TestingController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<TestingController>
        [HttpPost]
        public void Post(clsBuyer logs)
        {
            //logsDAL logsDAL = new logsDAL();
            //logsDAL.InsertLogs(logs);

            //googleCal();
        }

        // PUT api/<TestingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        //Send Email
        private  void Email(string htmlString)
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
                message.To.Add(new MailAddress("talhashaikh.333@gmail.com"));
                message.Subject = mailObj.mailSubject;
               message.IsBodyHtml = true; //to make message body as html  
               message.Body = PopulateEmailBody("Test Name","Test Title","evolvebitx.com","Dummy Description");
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
            catch (Exception ex) {
                throw;
            }
        }
        
        private string PopulateEmailBody(string userName, string title, string url, string description)
        {
             string body = string.Empty;
            using (StreamReader reader = new StreamReader("HtmlEmailTemplate/forgotPassword.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Url}", url);
            body = body.Replace("{Description}", description);
            return body;
        }

        private void googleCal()
        {
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                            new ClientSecrets
                            {
                                ClientId = "622925381624-esakldnldmv7hqss74u2lss1ubh2074p.apps.googleusercontent.com",
                                ClientSecret = "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",
                            },
                            new[] { CalendarService.Scope.Calendar },
                            "Web client 1",
                            CancellationToken.None).Result;
        }
            // Create the service.
            //var service = new CalendarService(new BaseClientService.Initializer
            //{
            //    HttpClientInitializer = credential,
            //    ApplicationName = "Calendar API Sample",
            //});
            //var myEvent = new Event
            //{
            //    Summary = "Google Calendar Api Sample Code",
            //    Location = "Time Medicos",
            //    Start = new EventDateTime
            //    {
            //        DateTime = DateTime.Now,
            //    },
            //    End = new EventDateTime
            //    {
            //        DateTime = DateTime.Now.AddDays(1),
            //    },
            //    Recurrence = new String[] { "RRULE:FREQ=WEEKLY;BYDAY=MO" },
            //    Attendees = new List<EventAttendee>
            //    {
            //    new EventAttendee { Email = "talhashaikh.333@gmail.com"}
            //    },
            //};

            //var recurringEvent = service.Events.Insert(myEvent, "primary");
            //recurringEvent.SendNotifications = true;
            //recurringEvent.Execute();

       // }
    }
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }     
    }
}
