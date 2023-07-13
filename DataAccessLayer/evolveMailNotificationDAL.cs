using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class evolveMailNotificationDAL : SQLDataAccess
    {
       
        public List<clsEvolveMailNotification> SelectEvolveMailNotificationByEmailType(string evolveMailType)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectEvolveMailNotificationByEmailType");
                comand.Parameters.AddWithValue("@evolveMailType", evolveMailType);
                List<clsEvolveMailNotification> activeList = new List<clsEvolveMailNotification>();
                TExecuteReaderCmd<clsEvolveMailNotification>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsEvolveMailNotification>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsEvolveMailNotification> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsEvolveMailNotification obj = new clsEvolveMailNotification();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.evolveMailTypeId = returnData["evolveMailTypeId"] is DBNull ? (int)0 : (int)returnData["evolveMailTypeId"];
                    obj.notificationEmail = returnData["notificationEmail"] is DBNull ? (string)string.Empty : (string)returnData["notificationEmail"];
                    obj.mailPassword = returnData["mailPassword"] is DBNull ? (string)string.Empty : (string)returnData["mailPassword"];
                    obj.mailPort = returnData["mailPort"] is DBNull ? (int)0 : (int)returnData["mailPort"];
                    obj.mailSmtp = returnData["mailSmtp"] is DBNull ? (string)string.Empty : (string)returnData["mailSmtp"];
                    obj.mailSubject = returnData["mailSubject"] is DBNull ? (string)string.Empty : (string)returnData["mailSubject"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    activeList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
