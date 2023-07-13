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
  public class standardProcessDAL : SQLDataAccess
    {
        
        public List<clsStandardProcess> SelectAllStandardProcess(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardProcess");

                List<clsStandardProcess> officeTypeList = new List<clsStandardProcess>();
                TExecuteReaderCmd<clsStandardProcess>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardProcess>, ref officeTypeList);
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
        public List<clsStandardProcess> SelectStandardProcessById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                comand.Parameters.AddWithValue("@id", id);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardProcessById");

                List<clsStandardProcess> officeTypeList = new List<clsStandardProcess>();
                TExecuteReaderCmd<clsStandardProcess>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardProcess>, ref officeTypeList);
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

        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardProcess> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardProcess obj = new clsStandardProcess();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationBodyStandardId = returnData["accreditationBodyStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationBodyStandardId"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.processName = returnData["processName"] is DBNull ? (string)string.Empty : (string)returnData["processName"];
                    obj.isExclusivePerDay = returnData["isExclusivePerDay"] is DBNull ? (bool)false : (bool)returnData["isExclusivePerDay"];
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
