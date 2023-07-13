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
   public class siteBillingInfoDAL : SQLDataAccess
    {
        public int InsertSiteBillingInfo(clsSiteBillingInfo obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingCompanyName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.billingCompanyName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.billingEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.billingPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingPhoneIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)obj.billingPhoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.billingWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingPostalCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.billingPostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingVatNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.billingVatNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingPhoneExt", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.billingPhoneExt ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingAddressLine1", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.billingAddressLine1 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingAddressLine2", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.billingAddressLine2 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingAddressLine3", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.billingAddressLine3 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertSiteBillingInfo", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateSiteBillingInfo(clsSiteBillingInfo obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingCompanyName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.billingCompanyName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.billingEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.billingPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingPhoneIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)obj.billingPhoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.billingWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingPostalCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.billingPostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingVatNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.billingVatNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingPhoneExt", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.billingPhoneExt ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingAddressLine1", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.billingAddressLine1 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingAddressLine2", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.billingAddressLine2 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@billingAddressLine3", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.billingAddressLine3 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateSiteBillingInfo", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsSiteBillingInfo> SelectAllSiteBillingInfo(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllSiteBillingInfo");

                List<clsSiteBillingInfo> activeList = new List<clsSiteBillingInfo>();
                TExecuteReaderCmd<clsSiteBillingInfo>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteBillingInfo>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteBillingInfo>();
        }
        public List<clsSiteBillingInfo> SelectSiteBillingInfoById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSiteBillingInfoById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsSiteBillingInfo> activeList = new List<clsSiteBillingInfo>();
                TExecuteReaderCmd<clsSiteBillingInfo>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteBillingInfo>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteBillingInfo>();
        }  
        public List<clsSiteBillingInfo> SelectSiteBillingInfoByAppIdClientSiteId(int appId,int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSiteBillingInfoByAppIdClientSiteId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsSiteBillingInfo> activeList = new List<clsSiteBillingInfo>();
                TExecuteReaderCmd<clsSiteBillingInfo>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteBillingInfo>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteBillingInfo>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsSiteBillingInfo> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsSiteBillingInfo obj = new clsSiteBillingInfo();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.billingCompanyName = returnData["billingCompanyName"] is DBNull ? (string)string.Empty : (string)returnData["billingCompanyName"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int)0 : (int)returnData["stateProvinceId"];
                    obj.cityId = returnData["cityId"] is DBNull ? (int)0 : (int)returnData["cityId"];
                    obj.billingEmail = returnData["billingEmail"] is DBNull ? (string)string.Empty : (string)returnData["billingEmail"];
                    obj.billingPhone = returnData["billingPhone"] is DBNull ? (string)string.Empty : (string)returnData["billingPhone"];
                    obj.billingPhoneIsoCode = returnData["billingPhoneIsoCode"] is DBNull ? (string)string.Empty : (string)returnData["billingPhoneIsoCode"];
                    obj.billingWebsite = returnData["billingWebsite"] is DBNull ? (string)string.Empty : (string)returnData["billingWebsite"];
                    obj.billingPostalCode = returnData["billingPostalCode"] is DBNull ? (string)string.Empty : (string)returnData["billingPostalCode"];
                    obj.billingVatNo = returnData["billingVatNo"] is DBNull ? (string)string.Empty : (string)returnData["billingVatNo"];
                    obj.billingPhoneExt = returnData["billingPhoneExt"] is DBNull ? (string)string.Empty : (string)returnData["billingPhoneExt"];
                    obj.billingAddressLine1 = returnData["billingAddressLine1"] is DBNull ? (string)string.Empty : (string)returnData["billingAddressLine1"];
                    obj.billingAddressLine2 = returnData["billingAddressLine2"] is DBNull ? (string)string.Empty : (string)returnData["billingAddressLine2"];
                    obj.billingAddressLine3 = returnData["billingAddressLine3"] is DBNull ? (string)string.Empty : (string)returnData["billingAddressLine3"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];

                    obj.countryName =ColumnExists(returnData, "countryName") ? returnData["countryName"] is DBNull ? (string)string.Empty : (string)returnData["countryName"] : string.Empty;
                    obj.stateProvinceName = ColumnExists(returnData, "stateProvinceName") ? returnData["stateProvinceName"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceName"] : string.Empty;
                    obj.cityName = ColumnExists(returnData, "cityName") ? returnData["cityName"] is DBNull ? (string)string.Empty : (string)returnData["cityName"] : string.Empty;


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
