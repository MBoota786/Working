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
   public class siteContactPersonGroupDAL : SQLDataAccess
    {
        public int InsertSiteContactPersonGroup(clsSiteContactPersonGroup obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnGroupName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.cntPrsnGroupName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertSiteContactPersonGroup", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateSiteContactPersonGroup(clsSiteContactPersonGroup obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnGroupName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.cntPrsnGroupName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateSiteContactPersonGroup", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsSiteContactPersonGroup> SelectAllSiteContactPersonGroup(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllSiteContactPersonGroup");

                List<clsSiteContactPersonGroup> activeList = new List<clsSiteContactPersonGroup>();
                TExecuteReaderCmd<clsSiteContactPersonGroup>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteContactPersonGroup>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteContactPersonGroup>();
        }  
        public List<clsSiteContactPersonGroup> SelectAllSiteContactPersonGroupForClient(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllSiteContactPersonGroupForClient");

                List<clsSiteContactPersonGroup> activeList = new List<clsSiteContactPersonGroup>();
                TExecuteReaderCmd<clsSiteContactPersonGroup>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteContactPersonGroup>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteContactPersonGroup>();
        }  public List<clsSiteContactPersonGroup> SelectAllSiteContactPersonGroupForSite(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllSiteContactPersonGroupForSite");

                List<clsSiteContactPersonGroup> activeList = new List<clsSiteContactPersonGroup>();
                TExecuteReaderCmd<clsSiteContactPersonGroup>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteContactPersonGroup>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteContactPersonGroup>();
        }
        public List<clsSiteContactPersonGroup> SelectSiteContactPersonGroupById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSiteContactPersonGroupById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsSiteContactPersonGroup> activeList = new List<clsSiteContactPersonGroup>();
                TExecuteReaderCmd<clsSiteContactPersonGroup>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteContactPersonGroup>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteContactPersonGroup>();
        }   
        public List<clsSiteContactPersonGroup> SelectSiteContactPersonGroupByName(string cntPrsnGroupName, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSiteContactPersonGroupByName");
                comand.Parameters.AddWithValue("@cntPrsnGroupName", cntPrsnGroupName);
                List<clsSiteContactPersonGroup> activeList = new List<clsSiteContactPersonGroup>();
                TExecuteReaderCmd<clsSiteContactPersonGroup>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteContactPersonGroup>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteContactPersonGroup>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsSiteContactPersonGroup> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsSiteContactPersonGroup obj = new clsSiteContactPersonGroup();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.cntPrsnGroupName = returnData["cntPrsnGroupName"] is DBNull ? (string)string.Empty : (string)returnData["cntPrsnGroupName"];
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
        public bool IsExistSiteContactPersonGroup(string cntPrsnGroupName, string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@cntPrsnGroupName", cntPrsnGroupName);
                return IsRecordExistCheck(cmd, "spIsExistSiteContactPersonGroup", dbName);
            }
        }
    }
}
