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
   public class riskLevelDAL : SQLDataAccess
    {
        public int InsertRiskLevel(clsRiskLevel obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@riskLevelName", SqlDbType.NVarChar, 50 , ParameterDirection.Input, (object)obj.riskLevelName?? DBNull.Value);
                AddParamToSQLCmd(comm, "@priorityLevel", SqlDbType.NVarChar, 50 , ParameterDirection.Input, (object)obj.priorityLevel?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertRiskLevel", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateRiskLevel(clsRiskLevel obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@riskLevelName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.riskLevelName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@priorityLevel", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.priorityLevel ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteInsertCommandReturnId(comm, "spUpdateRiskLevel", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsRiskLevel> SelectAllRiskLevel(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllRiskLevel");

                List<clsRiskLevel> activeList = new List<clsRiskLevel>();
                TExecuteReaderCmd<clsRiskLevel>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRiskLevel>, ref activeList);
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
        public List<clsRiskLevel> SelectRiskLevelById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectRiskLevelById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsRiskLevel> activeList = new List<clsRiskLevel>();
                TExecuteReaderCmd<clsRiskLevel>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRiskLevel>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsRiskLevel> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsRiskLevel obj = new clsRiskLevel();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                   obj.riskLevelName = returnData["riskLevelName"] is DBNull ? (string)string.Empty : (string)returnData["riskLevelName"];
                    obj.priorityLevel = returnData["priorityLevel"] is DBNull ? (string)string.Empty : (string)returnData["priorityLevel"];
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
