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
   public class siteSubTypeDAL : SQLDataAccess
    {
        public int InsertSiteSubType(clsSiteSubType obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subSiteTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.subSiteTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertSiteSubType", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateSiteSubType(clsSiteSubType obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subSiteTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.subSiteTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateSiteSubType", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsSiteSubType> SelectAllSiteSubType(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllSiteSubType");

                List<clsSiteSubType> activeList = new List<clsSiteSubType>();
                TExecuteReaderCmd<clsSiteSubType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteSubType>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteSubType>();
        }
        public List<clsSiteSubType> SelectSiteSubTypeById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSiteSubTypeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsSiteSubType> activeList = new List<clsSiteSubType>();
                TExecuteReaderCmd<clsSiteSubType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteSubType>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteSubType>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsSiteSubType> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsSiteSubType obj = new clsSiteSubType();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.siteTypeId = returnData["siteTypeId"] is DBNull ? (int)0 : (int)returnData["siteTypeId"];
                    obj.subSiteTypeName = returnData["subSiteTypeName"] is DBNull ? (string)string.Empty : (string)returnData["subSiteTypeName"];
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
