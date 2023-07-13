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
   public class appSiteEmpBreakDownDAL : SQLDataAccess
    {
        public int InsertAppSiteEmpBreakDown(clsAppSiteEmpBreakDown obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@managementEmp", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.managementEmp ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfWorkers", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfWorkers ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@workerMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.workerMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@workerFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.workerFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalEmployee", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalEmployee ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@managementMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.managementMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@managementFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.managementFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppSiteEmpBreakDown", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppSiteEmpBreakDown(clsAppSiteEmpBreakDown obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@managementEmp", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.managementEmp ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfWorkers", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfWorkers ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@workerMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.workerMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@workerFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.workerFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalEmployee", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalEmployee ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@managementMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.managementMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@managementFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.managementFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppSiteEmpBreakDown", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppSiteEmpBreakDown> SelectAllAppSiteEmpBreakDown(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppSiteEmpBreakDown");

                List<clsAppSiteEmpBreakDown> activeList = new List<clsAppSiteEmpBreakDown>();
                TExecuteReaderCmd<clsAppSiteEmpBreakDown>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteEmpBreakDown>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteEmpBreakDown>();
        }
        public List<clsAppSiteEmpBreakDown> SelectAppSiteEmpBreakDownById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppSiteEmpBreakDownById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppSiteEmpBreakDown> activeList = new List<clsAppSiteEmpBreakDown>();
                TExecuteReaderCmd<clsAppSiteEmpBreakDown>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteEmpBreakDown>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteEmpBreakDown>();
        }
        public List<clsAppSiteEmpBreakDown> SelectAppSiteEmpBreakDownByClientSiteIdAndAppId(int appId,int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppSiteEmpBreakDownByClientSiteIdAndAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsAppSiteEmpBreakDown> activeList = new List<clsAppSiteEmpBreakDown>();
                TExecuteReaderCmd<clsAppSiteEmpBreakDown>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteEmpBreakDown>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteEmpBreakDown>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppSiteEmpBreakDown> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppSiteEmpBreakDown obj = new clsAppSiteEmpBreakDown();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.managementEmp = returnData["managementEmp"] is DBNull ? (int)0 : (int)returnData["managementEmp"];
                    obj.noOfWorkers = returnData["noOfWorkers"] is DBNull ? (int)0 : (int)returnData["noOfWorkers"];
                    obj.workerMale = returnData["workerMale"] is DBNull ? (int)0 : (int)returnData["workerMale"];
                    obj.workerFemale = returnData["workerFemale"] is DBNull ? (int)0 : (int)returnData["workerFemale"];
                    obj.totalEmployee = returnData["totalEmployee"] is DBNull ? (int)0 : (int)returnData["totalEmployee"];
                    obj.managementMale = returnData["managementMale"] is DBNull ? (int)0 : (int)returnData["managementMale"];
                    obj.managementFemale = returnData["managementFemale"] is DBNull ? (int)0 : (int)returnData["managementFemale"];
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
