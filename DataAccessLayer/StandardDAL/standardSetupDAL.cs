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
  public class standardSetupDAL : SQLDataAccess
    {
        public int InsertStandardSetup(clsStandardSetup ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.accreditationStandardsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditCycleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.auditCycleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@industryCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.industryCategoryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@preRequisitesDocumentStatus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.preRequisitesDocumentStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditRequiredDocumentStatus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.auditRequiredDocumentStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@interviewSampling", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.interviewSampling ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditReportReviewCheckListStatus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.auditReportReviewCheckListStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@openingMeetingCheckListStatus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.openingMeetingCheckListStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@closingMeetingCheckListStatus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.closingMeetingCheckListStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@RiskTableStatus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.RiskTableStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteInsertCommandReturnId(comm, "spInsertStandardSetup", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStandardSetup(clsStandardSetup ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.accreditationStandardsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditCycleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.auditCycleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@industryCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.industryCategoryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@preRequisitesDocumentStatus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.preRequisitesDocumentStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditRequiredDocumentStatus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.auditRequiredDocumentStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@interviewSampling", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.interviewSampling ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditReportReviewCheckListStatus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.auditReportReviewCheckListStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@openingMeetingCheckListStatus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.openingMeetingCheckListStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@closingMeetingCheckListStatus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.closingMeetingCheckListStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@RiskTableStatus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.RiskTableStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateStandardSetup", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsStandardSetup> SelectAllStandardSetup(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardSetup");

                List<clsStandardSetup> activeList = new List<clsStandardSetup>();
                TExecuteReaderCmd<clsStandardSetup>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardSetup>, ref activeList);
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
        public List<clsStandardSetup> SelectStandardSetupById(int id, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbname);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardSetupById");
                comand.Parameters.AddWithValue("@id", id);
                
                List<clsStandardSetup> activeList = new List<clsStandardSetup>();
                TExecuteReaderCmd<clsStandardSetup>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardSetup>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardSetup> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardSetup obj = new clsStandardSetup();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationStandardsId = returnData["accreditationStandardsId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardsId"];
                    obj.auditCycleId = returnData["auditCycleId"] is DBNull ? (int)0 : (int)returnData["auditCycleId"];
                    obj.industryCategoryId = returnData["industryCategoryId"] is DBNull ? (int)0 : (int)returnData["industryCategoryId"];
                     obj.preRequisitesDocumentStatus = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
                     obj.auditRequiredDocumentStatus = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
                     obj.interviewSampling = returnData["interviewSampling"] is DBNull ? (string)string.Empty : (string)returnData["interviewSampling"];
                     obj.auditReportReviewCheckListStatus = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                     obj.openingMeetingCheckListStatus = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
                     obj.closingMeetingCheckListStatus = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
                     obj.RiskTableStatus = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
                     obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
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
