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
  public class setupStepsDAL : SQLDataAccess
    {
        
        public List<clsSetupSteps> SelectAllSetupSteps(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllSetupSteps");

                List<clsSetupSteps> officeTypeList = new List<clsSetupSteps>();
                TExecuteReaderCmd<clsSetupSteps>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSetupSteps>, ref officeTypeList);
                if (officeTypeList != null)
                {
                    return officeTypeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSetupSteps>();
        } 
        public List<clsSetupSteps> SelectChildStepByParentStepId(int parentStepId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectChildStepByParentStepId");
                comand.Parameters.AddWithValue("@parentStepId", parentStepId);
                List<clsSetupSteps> officeTypeList = new List<clsSetupSteps>();
                TExecuteReaderCmd<clsSetupSteps>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSetupSteps>, ref officeTypeList);
                if (officeTypeList != null)
                {
                    return officeTypeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSetupSteps>();
        }
     
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsSetupSteps> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsSetupSteps obj = new clsSetupSteps();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.stepName = returnData["stepName"] is DBNull ? (string)string.Empty : (string)returnData["stepName"];
                    obj.stepLink = returnData["stepLink"] is DBNull ? (string)string.Empty : (string)returnData["stepLink"];
                    obj.parentStepId = returnData["parentStepId"] is DBNull ? (int)0 : (int)returnData["parentStepId"];
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
