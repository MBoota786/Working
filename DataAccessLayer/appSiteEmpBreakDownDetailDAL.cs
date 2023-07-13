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
   public class appSiteEmpBreakDownDetailDAL : SQLDataAccess
    {
        public int InsertAppSiteEmpBreakDownDetail(clsAppSiteEmpBreakDownDetail obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isMigrant", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isMigrant ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isLocal", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isLocal ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permEmpMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.permEmpMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@tempEmpMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.tempEmpMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@agencyEmpMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.agencyEmpMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contractEmpMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.contractEmpMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@homeWokerMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.homeWokerMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permEmpFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.permEmpFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@tempEmpFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.tempEmpFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@agencyEmpFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.agencyEmpFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contractEmpFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.contractEmpFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@homeWorkerFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.homeWorkerFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalEmp", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalEmp ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppSiteEmpBreakDownDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppSiteEmpBreakDownDetail(clsAppSiteEmpBreakDownDetail obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isMigrant", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isMigrant ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isLocal", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isLocal ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permEmpMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.permEmpMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@tempEmpMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.tempEmpMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@agencyEmpMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.agencyEmpMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contractEmpMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.contractEmpMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@homeWokerMale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.homeWokerMale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permEmpFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.permEmpFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@tempEmpFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.tempEmpFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@agencyEmpFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.agencyEmpFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contractEmpFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.contractEmpFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@homeWorkerFemale", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.homeWorkerFemale ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalEmp", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalEmp ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppSiteEmpBreakDownDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppSiteEmpBreakDownDetail> SelectAllAppSiteEmpBreakDownDetail(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppSiteEmpBreakDownDetail");

                List<clsAppSiteEmpBreakDownDetail> activeList = new List<clsAppSiteEmpBreakDownDetail>();
                TExecuteReaderCmd<clsAppSiteEmpBreakDownDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteEmpBreakDownDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteEmpBreakDownDetail>();
        }
        public List<clsAppSiteEmpBreakDownDetail> SelectAppSiteEmpBreakDownDetailById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppSiteEmpBreakDownDetailById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppSiteEmpBreakDownDetail> activeList = new List<clsAppSiteEmpBreakDownDetail>();
                TExecuteReaderCmd<clsAppSiteEmpBreakDownDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteEmpBreakDownDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteEmpBreakDownDetail>();
        }
        public List<clsAppSiteEmpBreakDownDetail> SelectAppSiteEmpBreakDownDetailByClientSiteIdAndAppId(int appId,int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppSiteEmpBreakDownDetailByClientSiteIdAndAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsAppSiteEmpBreakDownDetail> activeList = new List<clsAppSiteEmpBreakDownDetail>();
                TExecuteReaderCmd<clsAppSiteEmpBreakDownDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteEmpBreakDownDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteEmpBreakDownDetail>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppSiteEmpBreakDownDetail> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppSiteEmpBreakDownDetail obj = new clsAppSiteEmpBreakDownDetail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.isMigrant = returnData["isMigrant"] is DBNull ? (bool) false : (bool)returnData["isMigrant"];
                    obj.isLocal = returnData["isLocal"] is DBNull ? (bool) false : (bool)returnData["isLocal"];
                    obj.permEmpMale = returnData["permEmpMale"] is DBNull ? (int)0 : (int)returnData["permEmpMale"];
                    obj.tempEmpMale = returnData["tempEmpMale"] is DBNull ? (int)0 : (int)returnData["tempEmpMale"];
                    obj.agencyEmpMale = returnData["agencyEmpMale"] is DBNull ? (int)0 : (int)returnData["agencyEmpMale"];
                    obj.contractEmpMale = returnData["contractEmpMale"] is DBNull ? (int)0 : (int)returnData["contractEmpMale"];
                    obj.homeWokerMale = returnData["homeWokerMale"] is DBNull ? (int)0 : (int)returnData["homeWokerMale"];
                    obj.permEmpFemale = returnData["permEmpFemale"] is DBNull ? (int)0 : (int)returnData["permEmpFemale"];
                    obj.tempEmpFemale = returnData["tempEmpFemale"] is DBNull ? (int)0 : (int)returnData["tempEmpFemale"];
                    obj.agencyEmpFemale = returnData["agencyEmpFemale"] is DBNull ? (int)0 : (int)returnData["agencyEmpFemale"];
                    obj.contractEmpFemale = returnData["contractEmpFemale"] is DBNull ? (int)0 : (int)returnData["contractEmpFemale"];
                    obj.homeWorkerFemale = returnData["homeWorkerFemale"] is DBNull ? (int)0 : (int)returnData["homeWorkerFemale"];
                    obj.totalEmp = returnData["totalEmp"] is DBNull ? (int)0 : (int)returnData["totalEmp"];
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
