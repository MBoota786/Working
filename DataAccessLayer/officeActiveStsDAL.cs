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
  public class officeActiveStsDAL : SQLDataAccess
    {
        
        public List<clsOfficeActiveSts> SelectAllOfficeActiveSts(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeActiveSts");

                List<clsOfficeActiveSts> officeTypeList = new List<clsOfficeActiveSts>();
                TExecuteReaderCmd<clsOfficeActiveSts>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeActiveSts>, ref officeTypeList);
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
     
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeActiveSts> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeActiveSts obj = new clsOfficeActiveSts();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeActiveStsName = returnData["officeActiveStsName"] is DBNull ? (string)string.Empty : (string)returnData["officeActiveStsName"];
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
