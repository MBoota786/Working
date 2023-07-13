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
   public class siteInfrastructureDAL : SQLDataAccess
    {
        public int InsertSiteInfrastructure(clsSiteInfrastructure obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@buildingName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.buildingName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfBuildingId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfBuildingId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sizeOfFacility", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.sizeOfFacility ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@buildingType", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.buildingType ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@numberOfFloors", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.numberOfFloors ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertSiteInfrastructure", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateSiteInfrastructure(clsSiteInfrastructure obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@buildingName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.buildingName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfBuildingId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfBuildingId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sizeOfFacility", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.sizeOfFacility ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@buildingType", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.buildingType ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@numberOfFloors", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.numberOfFloors ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateSiteInfrastructure", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool UpdateSiteInfrastructureForReview(clsSiteInfrastructure obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
             //   AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@buildingName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.buildingName ?? DBNull.Value);
              //  AddParamToSQLCmd(comm, "@noOfBuildingId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfBuildingId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sizeOfFacility", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.sizeOfFacility ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@buildingType", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.buildingType ?? DBNull.Value);
             //   AddParamToSQLCmd(comm, "@numberOfFloors", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.numberOfFloors ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
            //    AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateSiteInfrastructureForReview", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsSiteInfrastructure> SelectAllSiteInfrastructure(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllSiteInfrastructure");

                List<clsSiteInfrastructure> activeList = new List<clsSiteInfrastructure>();
                TExecuteReaderCmd<clsSiteInfrastructure>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteInfrastructure>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteInfrastructure>();
        }
        public List<clsSiteInfrastructure> SelectSiteInfrastructureById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSiteInfrastructureById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsSiteInfrastructure> activeList = new List<clsSiteInfrastructure>();
                TExecuteReaderCmd<clsSiteInfrastructure>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteInfrastructure>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteInfrastructure>();
        }    
        public List<clsSiteInfrastructure> SelectSiteInfrastructureByClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSiteInfrastructureByClientSiteId");
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsSiteInfrastructure> activeList = new List<clsSiteInfrastructure>();
                TExecuteReaderCmd<clsSiteInfrastructure>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteInfrastructure>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteInfrastructure>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsSiteInfrastructure> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsSiteInfrastructure obj = new clsSiteInfrastructure();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.buildingName = returnData["buildingName"] is DBNull ? (string) string.Empty : (string)returnData["buildingName"];
                    obj.noOfBuilding = returnData["noOfBuilding"] is DBNull ? (string) string.Empty : (string)returnData["noOfBuilding"];
                    obj.noOfBuildingId = returnData["noOfBuildingId"] is DBNull ? (int) 0 : (int)returnData["noOfBuildingId"];
                    obj.sizeOfFacility = returnData["sizeOfFacility"] is DBNull ? (int) 0 : (int)returnData["sizeOfFacility"];
                    obj.buildingType = returnData["buildingType"] is DBNull ? (string) string.Empty : (string)returnData["buildingType"];
                    obj.numberOfFloors = returnData["numberOfFloors"] is DBNull ? (int) 0 : (int)returnData["numberOfFloors"];
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
