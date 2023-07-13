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
   public class accreditationIndustrialCodesDAL : SQLDataAccess
    {
        public int InsertAccreditationIndustrialCodes(clsAccreditationIndustrialCodes obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationIndstrlCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accreditationIndstrlCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccreditationIndustrialCodes", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccreditationIndustrialCodes(clsAccreditationIndustrialCodes obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationIndstrlCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accreditationIndstrlCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationIndustrialCodes", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationIndustrialCodes> SelectAllAccreditationIndustrialCodes(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationIndustrialCodes");

                List<clsAccreditationIndustrialCodes> activeList = new List<clsAccreditationIndustrialCodes>();
                TExecuteReaderCmd<clsAccreditationIndustrialCodes>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationIndustrialCodes>, ref activeList);
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
        public List<clsAccreditationIndustrialCodes> SelectAccreditationIndustrialCodesById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationIndustrialCodesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationIndustrialCodes> activeList = new List<clsAccreditationIndustrialCodes>();
                TExecuteReaderCmd<clsAccreditationIndustrialCodes>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationIndustrialCodes>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationIndustrialCodes> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationIndustrialCodes obj = new clsAccreditationIndustrialCodes();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationIndstrlCode = returnData["accreditationIndstrlCode"] is DBNull ? (string)string.Empty : (string)returnData["accreditationIndstrlCode"];
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
