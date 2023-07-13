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
  public class StepStatusDAL : SQLDataAccess
    {
        
        public List<clsStepStatus> SelectAllstepStatus(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllstepStatus");

                List<clsStepStatus> officeTypeList = new List<clsStepStatus>();
                TExecuteReaderCmd<clsStepStatus>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStepStatus>, ref officeTypeList);
                if (officeTypeList != null)
                {
                    return officeTypeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
     
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStepStatus> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStepStatus obj = new clsStepStatus();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.stepStatusName = returnData["stepStatusName"] is DBNull ? (string)string.Empty : (string)returnData["stepStatusName"];
                    activeEmail.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
