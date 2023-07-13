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
   public class standardServiceFeeMasterDAL : SQLDataAccess
    {
        public int InsertStandardServiceFeeMaster(clsStandardServiceFeeMaster obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceFeeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.serviceFeeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isActive", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isActive ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isClientRecievable", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isClientRecievable ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isParentOfficePayable", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isParentOfficePayable ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@payableOfficeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.payableOfficeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@receivableOfficeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.receivableOfficeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceFeeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceFeeTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@tariffTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.tariffTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicableFromDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.applicableFromDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertStandardServiceFeeMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStandardServiceFeeMaster(clsStandardServiceFeeMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceFeeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.serviceFeeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isActive", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isActive ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isClientRecievable", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isClientRecievable ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isParentOfficePayable", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isParentOfficePayable ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@payableOfficeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.payableOfficeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@receivableOfficeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.receivableOfficeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceFeeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceFeeTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@tariffTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.tariffTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicableFromDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.applicableFromDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateStandardServiceFeeMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsStandardServiceFeeMaster> SelectAllStandardServiceFeeMaster(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardServiceFeeMaster");

                List<clsStandardServiceFeeMaster> activeList = new List<clsStandardServiceFeeMaster>();
                TExecuteReaderCmd<clsStandardServiceFeeMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardServiceFeeMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardServiceFeeMaster>();
        }
      
        public List<clsStandardServiceFeeMaster> SelectStandardServiceFeeMasterById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardServiceFeeMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsStandardServiceFeeMaster> activeList = new List<clsStandardServiceFeeMaster>();
                TExecuteReaderCmd<clsStandardServiceFeeMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardServiceFeeMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardServiceFeeMaster>();
        }
        public List<clsStandardServiceFeeMaster> SelectStandardServiceFeeMasterByReceivableOfficeId(int receivableOfficeId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardServiceFeeMasterByReceivableOfficeId");
                comand.Parameters.AddWithValue("@receivableOfficeId", receivableOfficeId);
                List<clsStandardServiceFeeMaster> activeList = new List<clsStandardServiceFeeMaster>();
                TExecuteReaderCmd<clsStandardServiceFeeMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardServiceFeeMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardServiceFeeMaster>();
        } 
        public List<clsStandardServiceFeeMaster> SelectStandardServiceFeeMasterByOfficeId(int officeId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardServiceFeeMasterByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsStandardServiceFeeMaster> activeList = new List<clsStandardServiceFeeMaster>();
                TExecuteReaderCmd<clsStandardServiceFeeMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardServiceFeeMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardServiceFeeMaster>();
        }   
        public List<clsStandardServiceFeeMaster> SelectStandardServiceFeeForQuotatonByAppIdClientSiteId(int appId, int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardServiceFeeForQuotatonByAppIdClientSiteId");
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                comand.Parameters.AddWithValue("@appId", appId);
                List<clsStandardServiceFeeMaster> activeList = new List<clsStandardServiceFeeMaster>();
                TExecuteReaderCmd<clsStandardServiceFeeMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardServiceFeeMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardServiceFeeMaster>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardServiceFeeMaster> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardServiceFeeMaster obj = new clsStandardServiceFeeMaster();
                    obj.id = ColumnExists(returnData,"id")? returnData["id"] is DBNull ? (int)0 : (int)returnData["id"] : 0;
                    obj.serviceFeeName = ColumnExists(returnData, "serviceFeeName") ? returnData["serviceFeeName"] is DBNull ? (string) string.Empty : (string)returnData["serviceFeeName"] : string.Empty;
                    obj.officeId = ColumnExists(returnData, "officeId") ? returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"] : 0;
                    obj.accreditationStandardId = ColumnExists(returnData, "accreditationStandardId") ? returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"] : 0;
                    obj.auditTypeId = ColumnExists(returnData, "auditTypeId") ? returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"] : 0;
                    obj.isActive = ColumnExists(returnData, "isActive") ? returnData["isActive"] is DBNull ? (bool)false : (bool)returnData["isActive"] : false;
                    obj.isClientRecievable = ColumnExists(returnData, "isClientRecievable") ?  returnData["isClientRecievable"] is DBNull ? (bool)false : (bool)returnData["isClientRecievable"] : false;
                    obj.isParentOfficePayable = ColumnExists(returnData, "isParentOfficePayable") ? returnData["isParentOfficePayable"] is DBNull ? (bool)false : (bool)returnData["isParentOfficePayable"] : false;
                    obj.payableOfficeId = ColumnExists(returnData, "payableOfficeId") ? returnData["payableOfficeId"] is DBNull ? (int)0 : (int)returnData["payableOfficeId"] : 0;
                    obj.receivableOfficeId = ColumnExists(returnData, "receivableOfficeId") ? returnData["receivableOfficeId"] is DBNull ? (int)0 : (int)returnData["receivableOfficeId"] : 0;
                    obj.serviceFeeTypeId = ColumnExists(returnData, "serviceFeeTypeId") ? returnData["serviceFeeTypeId"] is DBNull ? (int)0 : (int)returnData["serviceFeeTypeId"] : 0;
                    obj.tariffTypeId = ColumnExists(returnData, "tariffTypeId") ? returnData["tariffTypeId"] is DBNull ? (int)0 : (int)returnData["tariffTypeId"] : 0;
                    obj.tariffTypeName = ColumnExists(returnData, "tariffTypeName") ? returnData["tariffTypeName"] is DBNull ? (string) string.Empty : (string)returnData["tariffTypeName"] : string.Empty;
                    obj.applicableFromDate = ColumnExists(returnData, "applicableFromDate") ? returnData["applicableFromDate"] is DBNull ? (DateTime?)null : (DateTime)returnData["applicableFromDate"] : null;
                    obj.active = ColumnExists(returnData, "active") ? returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"] : false;
                    obj.createdOn = ColumnExists(returnData, "createdOn") ? returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"] : DateTime.Now;
                  
                    //Add For Quotation Fees
                    obj.currencySymbol = ColumnExists(returnData, "currencySymbol") ? returnData["currencySymbol"] is DBNull ? (string) string.Empty : (string)returnData["currencySymbol"] : string.Empty;
                    obj.standardName = ColumnExists(returnData, "standardName") ? returnData["standardName"] is DBNull ? (string) string.Empty : (string)returnData["standardName"] : string.Empty;
                    obj.auditTypeName = ColumnExists(returnData, "auditTypeName") ? returnData["auditTypeName"] is DBNull ? (string) string.Empty : (string)returnData["auditTypeName"] : string.Empty;
                    obj.feeName = ColumnExists(returnData, "feeName") ? returnData["feeName"] is DBNull ? (string) string.Empty : (string)returnData["feeName"] : string.Empty;
                    obj.serviceName = ColumnExists(returnData, "serviceName") ? returnData["serviceName"] is DBNull ? (string) string.Empty : (string)returnData["serviceName"] : string.Empty;
                    obj.criteriaName = ColumnExists(returnData, "criteriaName") ? returnData["criteriaName"] is DBNull ? (string) string.Empty : (string)returnData["criteriaName"] : string.Empty;
                    obj.clientSiteId = ColumnExists(returnData, "clientSiteId") ? returnData["clientSiteId"] is DBNull ? (int) 0 : (int)returnData["clientSiteId"] : 0;
                    obj.feeValue = ColumnExists(returnData, "feeValue") ? returnData["feeValue"] is DBNull ? (decimal) 0 : (decimal)returnData["feeValue"] : 0;
                    obj.auditTimePeriod = ColumnExists(returnData, "auditTimePeriod") ? returnData["auditTimePeriod"] is DBNull ? (int) 0 : (int)returnData["auditTimePeriod"] : 0;
                    obj.auditFee = ColumnExists(returnData, "auditFee") ? returnData["auditFee"] is DBNull ? (decimal) 0 : (decimal)returnData["auditFee"] : 0;
                    obj.actualFeeValue = ColumnExists(returnData, "actualFeeValue") ? returnData["actualFeeValue"] is DBNull ? (decimal)0 : (decimal)returnData["actualFeeValue"] : 0;
                    obj.actualAuditFee = ColumnExists(returnData, "actualAuditFee") ? returnData["actualAuditFee"] is DBNull ? (decimal)0 : (decimal)returnData["actualAuditFee"] : 0;
                    obj.standardServiceFeeId = ColumnExists(returnData, "standardServiceFeeId") ? returnData["standardServiceFeeId"] is DBNull ? (int)0 : (int)returnData["standardServiceFeeId"] : 0;
                    obj.standardServiceFeeDtlId = ColumnExists(returnData, "standardServiceFeeDtlId") ? returnData["standardServiceFeeDtlId"] is DBNull ? (int)0 : (int)returnData["standardServiceFeeDtlId"] : 0;

                    activeList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsServiceExistByAccreditationStandardId(int accreditationStandardId, string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@accreditationStandardId", accreditationStandardId);
                return IsRecordExistCheck(cmd, "IsServiceExistByAccreditationStandardId", dbName);
            }
        }
    }
}
