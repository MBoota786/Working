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
   public class applicationOfficeSitesDAL : SQLDataAccess
    {
        public int InsertApplicationOfficeSites(clsApplicationOfficeSites obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@shiftWiseStatus", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.shiftWiseStatus ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@isAllianceInspected", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAllianceInspected ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@totalAuditDaysCalculated", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalAuditDaysCalculated ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@totalAuditDaysFinal", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalAuditDaysFinal ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@isSiteEngagedWithConsultant", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSiteEngagedWithConsultant ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@siteCertificationScope", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.siteCertificationScope ?? DBNull.Value);
                   AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertApplicationOfficeSites", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateApplicationOfficeSites(clsApplicationOfficeSites obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@shiftWiseStatus", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.shiftWiseStatus ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@isAllianceInspected", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAllianceInspected ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@totalAuditDaysCalculated", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalAuditDaysCalculated ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@totalAuditDaysFinal", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalAuditDaysFinal ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSiteEngagedWithConsultant", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSiteEngagedWithConsultant ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteCertificationScope", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.siteCertificationScope ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateApplicationOfficeSites", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsApplicationOfficeSites> SelectAllApplicationOfficeSites(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllApplicationOfficeSites");

                List<clsApplicationOfficeSites> activeList = new List<clsApplicationOfficeSites>();
                TExecuteReaderCmd<clsApplicationOfficeSites>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationOfficeSites>, ref activeList);
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
        public List<clsApplicationOfficeSites> SelectApplicationOfficeSitesByAppId(int appId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationOfficeSitesByAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                List<clsApplicationOfficeSites> activeList = new List<clsApplicationOfficeSites>();
                TExecuteReaderCmd<clsApplicationOfficeSites>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationOfficeSites>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationOfficeSites>();
        }  
        public List<clsApplicationOfficeSites> SelectApplicationOfficeSitesByAppIdClientSiteId(int appId,int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationOfficeSitesByAppIdClientSiteId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsApplicationOfficeSites> activeList = new List<clsApplicationOfficeSites>();
                TExecuteReaderCmd<clsApplicationOfficeSites>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationOfficeSites>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationOfficeSites>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsApplicationOfficeSites> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsApplicationOfficeSites obj = new clsApplicationOfficeSites();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.siteCertificationScope = returnData["siteCertificationScope"] is DBNull ? (string)string.Empty : (string)returnData["siteCertificationScope"];
                    obj.isSiteEngagedWithConsultant = returnData["isSiteEngagedWithConsultant"] is DBNull ? (bool)true : (bool)returnData["isSiteEngagedWithConsultant"];
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
