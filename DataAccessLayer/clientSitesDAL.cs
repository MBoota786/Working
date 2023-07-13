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
   public class clientSitesDAL : SQLDataAccess
    {
        public int InsertClientSites(clsClientSites obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteCode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.clientSiteCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.siteName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sitePhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.sitePhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteVatNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteVatNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDormitoriesAllow", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDormitoriesAllow ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isMigrantWorkersAllow", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isMigrantWorkersAllow ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteSubTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteSubTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sitePostalCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.sitePostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@phoneIsoCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.phoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEngagedConsultant", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isEngagedConsultant ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sitePhoneExt", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.sitePhoneExt ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@siteAddressLine1", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteAddressLine1 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteAddressLine2", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteAddressLine2 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteAddressLine3", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteAddressLine3 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteLatitude", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteLatitude ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteLongitude", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteLongitude ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityPlotArea", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteFacilityPlotArea ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityCoverArea", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteFacilityCoverArea ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteNumberOfBuilding", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteNumberOfBuilding ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientSites", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientSites(clsClientSites obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.siteName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteAddressLine1", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteAddressLine1 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteAddressLine2", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteAddressLine2 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteAddressLine3", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteAddressLine3 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sitePhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.sitePhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteVatNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteVatNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDormitoriesAllow", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDormitoriesAllow ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isMigrantWorkersAllow", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isMigrantWorkersAllow ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteSubTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteSubTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sitePostalCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.sitePostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@phoneIsoCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.phoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEngagedConsultant", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isEngagedConsultant ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sitePhoneExt", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.sitePhoneExt ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteLatitude", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteLatitude ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteLongitude", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteLongitude ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityPlotArea", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteFacilityPlotArea ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityCoverArea", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteFacilityCoverArea ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteNumberOfBuilding", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteNumberOfBuilding ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientSites", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }  
        public bool UpdateClientSitesForReview(clsClientSites obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.siteName ?? DBNull.Value);
            //    AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
             //   AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
             //   AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteAddressLine1", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteAddressLine1 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteAddressLine2", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteAddressLine2 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteAddressLine3", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteAddressLine3 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sitePhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.sitePhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteVatNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteVatNo ?? DBNull.Value);
              //  AddParamToSQLCmd(comm, "@isDormitoriesAllow", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDormitoriesAllow ?? DBNull.Value);
             //   AddParamToSQLCmd(comm, "@isMigrantWorkersAllow", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isMigrantWorkersAllow ?? DBNull.Value);
           //     AddParamToSQLCmd(comm, "@sitePostalCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.sitePostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@phoneIsoCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.phoneIsoCode ?? DBNull.Value);
              //  AddParamToSQLCmd(comm, "@isEngagedConsultant", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isEngagedConsultant ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sitePhoneExt", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.sitePhoneExt ?? DBNull.Value);
             //   AddParamToSQLCmd(comm, "@siteLatitude", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteLatitude ?? DBNull.Value);
            //    AddParamToSQLCmd(comm, "@siteLongitude", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.siteLongitude ?? DBNull.Value);
            //    AddParamToSQLCmd(comm, "@siteFacilityPlotArea", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteFacilityPlotArea ?? DBNull.Value);
            //    AddParamToSQLCmd(comm, "@siteFacilityCoverArea", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteFacilityCoverArea ?? DBNull.Value);
            //    AddParamToSQLCmd(comm, "@siteNumberOfBuilding", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteNumberOfBuilding ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
           //     AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientSitesForReview", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        } 
        public bool UpdateClientSitesIsEngaged(clsClientSites obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEngagedConsultant", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isEngagedConsultant ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientSitesIsEngaged", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsClientSites> SelectAllClientSites(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientSites");

                List<clsClientSites> activeList = new List<clsClientSites>();
                TExecuteReaderCmd<clsClientSites>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSites>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSites>();
        }
        public List<clsClientSites> SelectClientSitesById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientSitesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientSites> activeList = new List<clsClientSites>();
                TExecuteReaderCmd<clsClientSites>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSites>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSites>();
        }
        public List<clsClientSites> SelectClientSitesByClientId(int clientId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientSitesByClientId");
                comand.Parameters.AddWithValue("@clientId", clientId);
                List<clsClientSites> activeList = new List<clsClientSites>();
                TExecuteReaderCmd<clsClientSites>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSites>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSites>();
        }   
        public List<clsClientSites> SelectClientSitesByClientIdAndAppId(int clientId,int appId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientSitesByClientIdAndAppId");
                comand.Parameters.AddWithValue("@clientId", clientId);
                comand.Parameters.AddWithValue("@appId", appId);
                List<clsClientSites> activeList = new List<clsClientSites>();
                TExecuteReaderCmd<clsClientSites>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSites>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSites>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientSites> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientSites obj = new clsClientSites();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientSiteCode = returnData["clientSiteCode"] is DBNull ? (string) string.Empty : (string)returnData["clientSiteCode"];
                    obj.clientId = returnData["clientId"] is DBNull ? (int)0 : (int)returnData["clientId"];
                    obj.siteTypeId = returnData["siteTypeId"] is DBNull ? (int)0 : (int)returnData["siteTypeId"];
                    obj.siteName = returnData["siteName"] is DBNull ? (string)string.Empty : (string)returnData["siteName"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int)0 : (int)returnData["stateProvinceId"];
                    obj.cityId = returnData["cityId"] is DBNull ? (int)0 : (int)returnData["cityId"];
                    obj.siteEmail = returnData["siteEmail"] is DBNull ? (string)string.Empty : (string)returnData["siteEmail"];
                    obj.sitePhone = returnData["sitePhone"] is DBNull ? (string)string.Empty : (string)returnData["sitePhone"];
                    obj.siteVatNo = returnData["siteVatNo"] is DBNull ? (string)string.Empty : (string)returnData["siteVatNo"];
                    obj.isDormitoriesAllow = returnData["isDormitoriesAllow"] is DBNull ? (bool)true : (bool)returnData["isDormitoriesAllow"];
                    obj.isMigrantWorkersAllow = returnData["isMigrantWorkersAllow"] is DBNull ? (bool)true : (bool)returnData["isMigrantWorkersAllow"];
                    obj.siteSubTypeId = returnData["siteSubTypeId"] is DBNull ? (int)0: (int)returnData["siteSubTypeId"];
                    obj.sitePostalCode = returnData["sitePostalCode"] is DBNull ? (string) string.Empty : (string)returnData["sitePostalCode"];
                    obj.siteWebsite = returnData["siteWebsite"] is DBNull ? (string) string.Empty : (string)returnData["siteWebsite"];
                    obj.phoneIsoCode = returnData["phoneIsoCode"] is DBNull ? (string) string.Empty : (string)returnData["phoneIsoCode"];
                    obj.isEngagedConsultant = returnData["isEngagedConsultant"] is DBNull ? (bool)true : (bool)returnData["isEngagedConsultant"];
                    obj.sitePhoneExt = returnData["sitePhoneExt"] is DBNull ? (string) string.Empty : (string)returnData["sitePhoneExt"];
                    obj.siteAddressLine1 = returnData["siteAddressLine1"] is DBNull ? (string)string.Empty : (string)returnData["siteAddressLine1"];
                    obj.siteAddressLine2 = returnData["siteAddressLine2"] is DBNull ? (string)string.Empty : (string)returnData["siteAddressLine2"];
                    obj.siteAddressLine3 = returnData["siteAddressLine3"] is DBNull ? (string)string.Empty : (string)returnData["siteAddressLine3"];
                    if (ColumnExists(returnData, "siteLatitude"))
                    {
                        obj.siteLatitude = returnData["siteLatitude"] is DBNull ? (string)string.Empty : (string)returnData["siteLatitude"];
                    }
                    if (ColumnExists(returnData, "siteLongitude"))
                    {
                        obj.siteLongitude = returnData["siteLongitude"] is DBNull ? (string)string.Empty : (string)returnData["siteLongitude"];
                    }  
                    if (ColumnExists(returnData, "siteFacilityPlotArea"))
                    {
                        obj.siteFacilityPlotArea = returnData["siteFacilityPlotArea"] is DBNull ? (string)string.Empty : (string)returnData["siteFacilityPlotArea"];
                    }     
                    if (ColumnExists(returnData, "siteFacilityCoverArea"))
                    {
                        obj.siteFacilityCoverArea = returnData["siteFacilityCoverArea"] is DBNull ? (string)string.Empty : (string)returnData["siteFacilityCoverArea"];
                    }
                    if (ColumnExists(returnData, "siteNumberOfBuilding"))
                    {
                        obj.siteNumberOfBuilding = returnData["siteNumberOfBuilding"] is DBNull ? (int)  0 : (int)returnData["siteNumberOfBuilding"];
                    }
                    if (ColumnExists(returnData, "siteTypeName"))
                    {
                        obj.siteTypeName = returnData["siteTypeName"] is DBNull ? (string)  string.Empty : (string)returnData["siteTypeName"];
                    } 
                    if (ColumnExists(returnData, "serviceAcquired"))
                    {
                        obj.serviceAcquired = returnData["serviceAcquired"] is DBNull ? (string)  string.Empty : (string)returnData["serviceAcquired"];
                    }
                    if (ColumnExists(returnData, "siteCertificationScope"))
                    {
                        obj.siteCertificationScope = returnData["siteCertificationScope"] is DBNull ? (string)  string.Empty : (string)returnData["siteCertificationScope"];
                    }
                    obj.countryName = ColumnExists(returnData, "countryName") ? returnData["countryName"] is DBNull ? (string)string.Empty : (string)returnData["countryName"] :string.Empty;
                    obj.stateProvinceName = ColumnExists(returnData, "stateProvinceName") ? returnData["stateProvinceName"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceName"] :string.Empty;
                    obj.cityName = ColumnExists(returnData, "cityName") ? returnData["cityName"] is DBNull ? (string)string.Empty : (string)returnData["cityName"] :string.Empty;
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
