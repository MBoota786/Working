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
   public class siteInfrastructureMasterDAL : SQLDataAccess
    {
        public int InsertSiteInfrastructureMaster(clsSiteInfrastructureMaster obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityCoverArea", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteFacilityCoverArea ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityPlotArea", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteFacilityPlotArea ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityCoverAreaUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteFacilityCoverAreaUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityPlotAreaUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteFacilityPlotAreaUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteNumberOfBuilding", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteNumberOfBuilding ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertSiteInfrastructureMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateSiteInfrastructureMaster(clsSiteInfrastructureMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityCoverArea", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteFacilityCoverArea ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityPlotArea", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteFacilityPlotArea ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityCoverAreaUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteFacilityCoverAreaUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityPlotAreaUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteFacilityPlotAreaUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteNumberOfBuilding", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteNumberOfBuilding ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateSiteInfrastructureMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        } 
        public bool UpdateSiteInfrastructureMasterForReview(clsSiteInfrastructureMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
              //  AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityCoverArea", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteFacilityCoverArea ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteFacilityPlotArea", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteFacilityPlotArea ?? DBNull.Value);
             //   AddParamToSQLCmd(comm, "@siteNumberOfBuilding", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteNumberOfBuilding ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
             //   AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateSiteInfrastructureMasterForReview", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsSiteInfrastructureMaster> SelectAllSiteInfrastructureMaster(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllSiteInfrastructureMaster");

                List<clsSiteInfrastructureMaster> adressList = new List<clsSiteInfrastructureMaster>();
                TExecuteReaderCmd<clsSiteInfrastructureMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteInfrastructureMaster>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteInfrastructureMaster>();
        }
        public List<clsSiteInfrastructureMaster> SelectSiteInfrastructureMasterById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSiteInfrastructureMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsSiteInfrastructureMaster> adressList = new List<clsSiteInfrastructureMaster>();
                TExecuteReaderCmd<clsSiteInfrastructureMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteInfrastructureMaster>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteInfrastructureMaster>();
        }
        public List<clsSiteInfrastructureMaster> SelectSiteInfrastructureMasterByClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSiteInfrastructureMasterByClientSiteId");
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsSiteInfrastructureMaster> adressList = new List<clsSiteInfrastructureMaster>();
                TExecuteReaderCmd<clsSiteInfrastructureMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteInfrastructureMaster>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteInfrastructureMaster>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsSiteInfrastructureMaster> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsSiteInfrastructureMaster obj = new clsSiteInfrastructureMaster();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.siteFacilityCoverArea = returnData["siteFacilityCoverArea"] is DBNull ? (string)string.Empty : (string)returnData["siteFacilityCoverArea"];
                    obj.siteFacilityPlotArea = returnData["siteFacilityPlotArea"] is DBNull ? (string)string.Empty : (string)returnData["siteFacilityPlotArea"];
                    obj.siteFacilityPlotAreaUnitName = returnData["siteFacilityPlotAreaUnitName"] is DBNull ? (string)string.Empty : (string)returnData["siteFacilityPlotAreaUnitName"];
                    obj.siteFacilityCoverAreaUnitName = returnData["siteFacilityCoverAreaUnitName"] is DBNull ? (string)string.Empty : (string)returnData["siteFacilityCoverAreaUnitName"];
                    obj.siteFacilityCoverAreaUnitId = returnData["siteFacilityCoverAreaUnitId"] is DBNull ? (int)0 : (int)returnData["siteFacilityCoverAreaUnitId"];
                    obj.siteFacilityPlotAreaUnitId = returnData["siteFacilityPlotAreaUnitId"] is DBNull ? (int)0 : (int)returnData["siteFacilityPlotAreaUnitId"];
                    obj.siteNumberOfBuilding = returnData["siteNumberOfBuilding"] is DBNull ? (int)0 : (int)returnData["siteNumberOfBuilding"];
                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    activeEmail.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
