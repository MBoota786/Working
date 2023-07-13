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
   public class appSiteAuditDaysDetailDAL : SQLDataAccess
    {
        public int InsertAppSiteAuditDaysDetail(clsAppSiteAuditDaysDetail obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accredationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accredationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalNoOfEmp", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalNoOfEmp ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@minAuditDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.minAuditDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@calculatedAuditDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.calculatedAuditDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@finalAuditDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.finalAuditDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppSiteAuditDaysDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppSiteAuditDaysDetail(clsAppSiteAuditDaysDetail obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accredationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accredationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalNoOfEmp", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalNoOfEmp ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@minAuditDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.minAuditDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@calculatedAuditDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.calculatedAuditDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@finalAuditDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.finalAuditDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppSiteAuditDaysDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppSiteAuditDaysDetail> spSelectAllAppSiteAuditDaysDetail(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppSiteAuditDaysDetail");

                List<clsAppSiteAuditDaysDetail> activeList = new List<clsAppSiteAuditDaysDetail>();
                TExecuteReaderCmd<clsAppSiteAuditDaysDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteAuditDaysDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteAuditDaysDetail>();
        }
        public List<clsAppSiteAuditDaysDetail> SelectAppSiteAuditDaysDetailByAppIdClientSiteId(int appId , int clientSiteId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppSiteAuditDaysDetailByAppIdClientSiteId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsAppSiteAuditDaysDetail> activeList = new List<clsAppSiteAuditDaysDetail>();
                TExecuteReaderCmd<clsAppSiteAuditDaysDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteAuditDaysDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteAuditDaysDetail>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppSiteAuditDaysDetail> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppSiteAuditDaysDetail obj = new clsAppSiteAuditDaysDetail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.accredationStandardId = returnData["accredationStandardId"] is DBNull ? (int)0 : (int)returnData["accredationStandardId"];
                    obj.totalNoOfEmp = returnData["totalNoOfEmp"] is DBNull ? (int)0 : (int)returnData["totalNoOfEmp"];
                    obj.minAuditDays = returnData["minAuditDays"] is DBNull ? (int)0 : (int)returnData["minAuditDays"];
                    obj.calculatedAuditDays = returnData["calculatedAuditDays"] is DBNull ? (int)0 : (int)returnData["calculatedAuditDays"];
                    obj.finalAuditDays = returnData["finalAuditDays"] is DBNull ? (int)0 : (int)returnData["finalAuditDays"];
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
