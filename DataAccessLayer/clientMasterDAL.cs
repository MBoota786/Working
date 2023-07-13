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
   public class clientMasterDAL : SQLDataAccess
    {
        public int InsertClientMaster(clsClientMaster obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientCompanyName ", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientCompanyName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientVatNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientVatNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientActivateBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientActivateBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@businessTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.businessTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@activeDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.activeDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceAcquired", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.serviceAcquired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientFolderName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientFolderName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientPostalCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientPostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientPhoneIsoCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientPhoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientPhoneExt", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.clientPhoneExt ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAddressLine1", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)obj.clientAddressLine1 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAddressLine2", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)obj.clientAddressLine2 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAddressLine3", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)obj.clientAddressLine3 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientMaster(clsClientMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientCompanyName ", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientCompanyName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientVatNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientVatNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientActivateBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientActivateBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@businessTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.businessTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@activeDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.activeDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceAcquired", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.serviceAcquired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientFolderName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientFolderName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientPostalCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientPostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientPhoneIsoCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientPhoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientPhoneExt", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.clientPhoneExt ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAddressLine1", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)obj.clientAddressLine1 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAddressLine2", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)obj.clientAddressLine2 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAddressLine3", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)obj.clientAddressLine3 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool UpdateClientMasterForReview(clsClientMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientCompanyName ", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientCompanyName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientVatNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientVatNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@businessTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.businessTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientPhoneIsoCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clientPhoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientPhoneExt", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.clientPhoneExt ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAddressLine1", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)obj.clientAddressLine1 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAddressLine2", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)obj.clientAddressLine2 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAddressLine3", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)obj.clientAddressLine3 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientMasterForReview", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsClientMaster> SelectAllClientMaster(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientMaster");

                List<clsClientMaster> activeList = new List<clsClientMaster>();
                TExecuteReaderCmd<clsClientMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientMaster>();
        }
        public List<clsClientMaster> SelectClientMasterById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientMaster> activeList = new List<clsClientMaster>();
                TExecuteReaderCmd<clsClientMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientMaster>();
        } 
        public List<clsClientMaster> spSelectClientMasterByQuotationId(int quotationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientMasterByQuotationId");
                comand.Parameters.AddWithValue("@quotationId", quotationId);
                List<clsClientMaster> activeList = new List<clsClientMaster>();
                TExecuteReaderCmd<clsClientMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientMaster>();
        } 
        public List<clsClientMaster> SelectAllClientMasterByOfficeId(int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientMasterByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsClientMaster> activeList = new List<clsClientMaster>();
                TExecuteReaderCmd<clsClientMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientMaster>();
        }  
        public List<clsClientMaster> SearchClientByCompanyName(string clientCompanyName,int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSearchClientByCompanyName");
                comand.Parameters.AddWithValue("@clientCompanyName", clientCompanyName);
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsClientMaster> activeList = new List<clsClientMaster>();
                TExecuteReaderCmd<clsClientMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientMaster>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientMaster> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientMaster obj = new clsClientMaster();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientCompanyName = returnData["clientCompanyName"] is DBNull ? (string)string.Empty : (string)returnData["clientCompanyName"];
                    obj.clientTypeId = returnData["clientTypeId"] is DBNull ? (int)0 : (int)returnData["clientTypeId"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int)0 : (int)returnData["stateProvinceId"];
                    obj.cityId = returnData["cityId"] is DBNull ? (int)0 : (int)returnData["cityId"];
                    obj.clientEmail = returnData["clientEmail"] is DBNull ? (string)string.Empty : (string)returnData["clientEmail"];
                    obj.clientPhone = returnData["clientPhone"] is DBNull ? (string)string.Empty : (string)returnData["clientPhone"];
                    obj.clientWebsite = returnData["clientWebsite"] is DBNull ? (string)string.Empty : (string)returnData["clientWebsite"];
                    obj.businessTypeId = returnData["businessTypeId"] is DBNull ? (int)0 : (int)returnData["businessTypeId"];
                    obj.otherBusinessType = returnData["otherBusinessType"] is DBNull ? (string)string.Empty : (string)returnData["otherBusinessType"];
                    obj.clientVatNo = returnData["clientVatNo"] is DBNull ? (string)string.Empty : (string)returnData["clientVatNo"];
                    obj.clientActivateBy = returnData["clientActivateBy"] is DBNull ? (int)0 : (int)returnData["clientActivateBy"];
                    obj.activeDate = returnData["activeDate"] is DBNull ? (DateTime?)null: (DateTime)returnData["activeDate"];
                    obj.serviceAcquired = returnData["serviceAcquired"] is DBNull ? (string) string.Empty : (string)returnData["serviceAcquired"];
                    obj.clientStatusId = returnData["clientStatusId"] is DBNull ? (int) 0: (int)returnData["clientStatusId"];
                    obj.clientFolderName = returnData["clientFolderName"] is DBNull ? (string)string.Empty: (string)returnData["clientFolderName"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int) 0 : (int)returnData["officeId"];
                    obj.clientPostalCode = returnData["clientPostalCode"] is DBNull ? (string)string.Empty: (string)returnData["clientPostalCode"];
                    obj.clientCode = returnData["clientCode"] is DBNull ? (string)string.Empty: (string)returnData["clientCode"];
                    obj.clientPhoneIsoCode = returnData["clientPhoneIsoCode"] is DBNull ? (string)string.Empty: (string)returnData["clientPhoneIsoCode"];
                    obj.clientPhoneExt = returnData["clientPhoneExt"] is DBNull ? (string)string.Empty: (string)returnData["clientPhoneExt"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    obj.clientAddressLine1 = returnData["clientAddressLine1"] is DBNull ? (string)string.Empty : (string)returnData["clientAddressLine1"];
                    obj.clientAddressLine2 = returnData["clientAddressLine2"] is DBNull ? (string)string.Empty : (string)returnData["clientAddressLine2"];
                    obj.clientAddressLine3 = returnData["clientAddressLine3"] is DBNull ? (string)string.Empty : (string)returnData["clientAddressLine3"];
                    if (ColumnExists(returnData, "clientTypeName"))
                    {
                        obj.clientTypeName = returnData["clientTypeName"] is DBNull ? (string)string.Empty : (string)returnData["clientTypeName"];
                    }
                    if (ColumnExists(returnData, "businessTypeName"))
                    {
                        obj.businessTypeName = returnData["businessTypeName"] is DBNull ? (string)string.Empty : (string)returnData["businessTypeName"];
                    } 
                    if (ColumnExists(returnData, "siteName"))
                    {
                        obj.siteName = returnData["siteName"] is DBNull ? (string)string.Empty : (string)returnData["siteName"];
                    }
                    if (ColumnExists(returnData, "countryName"))
                    {
                        obj.countryName = returnData["countryName"] is DBNull ? (string)string.Empty : (string)returnData["countryName"];
                    }  if (ColumnExists(returnData, "stateProvinceName"))
                    {
                        obj.stateProvinceName = returnData["stateProvinceName"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceName"];
                    } if (ColumnExists(returnData, "cityName"))
                    {
                        obj.cityName = returnData["cityName"] is DBNull ? (string)string.Empty : (string)returnData["cityName"];
                    }
                    activeList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetMaxCode(string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                return ExecuteReaderStringCode(cmd, "spGetClientMasterMaxCode", dbName);
            }
        }
    }
}
