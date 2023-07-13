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
  public class standardProcessStageDAL : SQLDataAccess
    {
        
        public List<clsStandardProcessStage> SelectAllStandardProcessStage(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardProcessStage");

                List<clsStandardProcessStage> officeTypeList = new List<clsStandardProcessStage>();
                TExecuteReaderCmd<clsStandardProcessStage>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardProcessStage>, ref officeTypeList);
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
        public List<clsStandardProcessStage> SelectStandardProcessStageById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                comand.Parameters.AddWithValue("@id", id);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardProcessStageById");

                List<clsStandardProcessStage> officeTypeList = new List<clsStandardProcessStage>();
                TExecuteReaderCmd<clsStandardProcessStage>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardProcessStage>, ref officeTypeList);
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

        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardProcessStage> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardProcessStage obj = new clsStandardProcessStage();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.standardProcessId = returnData["standardProcessId"] is DBNull ? (int)0 : (int)returnData["standardProcessId"];
                    obj.processStageName = returnData["processStageName"] is DBNull ? (string)string.Empty : (string)returnData["processStageName"];
                    obj.kpiTimeInHour = returnData["kpiTimeInHour"] is DBNull ? (int) 0 : (int)returnData["kpiTimeInHour"];
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
