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
   public class auditStandardsDAL : SQLDataAccess
    {
        public int InsertAuditStandards(clsAuditStandards ls)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardName", SqlDbType.VarChar, 100, ParameterDirection.Input, (object)ls.standardName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);

                Id = ExecuteInsertCommandReturnId(comm, "spInsertAuditStandards", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAuditStandards(clsAuditStandards ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardName", SqlDbType.VarChar, 100, ParameterDirection.Input, (object)ls.standardName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);

                ExecuteNonQueryCommand(comm, "spUpdateAuditStandards", ls.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAuditStandards> SelectAllAuditStandards(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditStandards");

                List<clsAuditStandards> activeList = new List<clsAuditStandards>();
                TExecuteReaderCmd<clsAuditStandards>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsAuditStandards>, ref activeList);
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
        public List<clsAuditStandards> SelectAuditStandardsById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditStandardsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAuditStandards> activeList = new List<clsAuditStandards>();
                TExecuteReaderCmd<clsAuditStandards>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsAuditStandards>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveStatusList<T>(SqlDataReader returnData, ref List<clsAuditStandards> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditStandards obj = new clsAuditStandards();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.standardName = returnData["standardName"] is DBNull ? (string)string.Empty : (string)returnData["standardName"];
                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
                    
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
