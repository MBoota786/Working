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
   public class siteDormitoriesDAL : SQLDataAccess
    {
        public int InsertSiteDormitories(clsSiteDormitories obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAccommodationFacilityToWorker", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAccommodationFacilityToWorker ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@perOfWorkerLiving", SqlDbType.Decimal , 18, ParameterDirection.Input, (object)obj.perOfWorkerLiving ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWorkerOnSite", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWorkerOnSite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWorkerOffSite", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWorkerOffSite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWorkerOnOffBoth", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWorkerOnOffBoth ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAccommodationFacilityToEmployees", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAccommodationFacilityToEmployees ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@perOfManagementLiving", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.perOfManagementLiving ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isManagementOnSite", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isManagementOnSite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isManagementOffSite", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isManagementOffSite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isManagementWorkerOnOffBoth", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isManagementWorkerOnOffBoth ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertSiteDormitories", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateSiteDormitories(clsSiteDormitories obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAccommodationFacilityToWorker", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAccommodationFacilityToWorker ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@perOfWorkerLiving", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.perOfWorkerLiving ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWorkerOnSite", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWorkerOnSite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWorkerOffSite", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWorkerOffSite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWorkerOnOffBoth", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWorkerOnOffBoth ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAccommodationFacilityToEmployees", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAccommodationFacilityToEmployees ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@perOfManagementLiving", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.perOfManagementLiving ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isManagementOnSite", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isManagementOnSite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isManagementOffSite", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isManagementOffSite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isManagementWorkerOnOffBoth", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isManagementWorkerOnOffBoth ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateSiteDormitories", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsSiteDormitories> SelectAllSiteDormitories(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllSiteDormitories");

                List<clsSiteDormitories> activeList = new List<clsSiteDormitories>();
                TExecuteReaderCmd<clsSiteDormitories>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteDormitories>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteDormitories>();
        }
        public List<clsSiteDormitories> SelectSiteDormitoriesById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSiteDormitoriesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsSiteDormitories> activeList = new List<clsSiteDormitories>();
                TExecuteReaderCmd<clsSiteDormitories>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteDormitories>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteDormitories>();
        }
        public List<clsSiteDormitories> SelectSiteDormitoriesByClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSiteDormitoriesByClientSiteId");
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsSiteDormitories> activeList = new List<clsSiteDormitories>();
                TExecuteReaderCmd<clsSiteDormitories>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSiteDormitories>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSiteDormitories>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsSiteDormitories> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsSiteDormitories obj = new clsSiteDormitories();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.isAccommodationFacilityToWorker = returnData["isAccommodationFacilityToWorker"] is DBNull ? (bool)false : (bool)returnData["isAccommodationFacilityToWorker"];
                    obj.perOfWorkerLiving = returnData["perOfWorkerLiving"] is DBNull ? (decimal) 0 : (decimal)returnData["perOfWorkerLiving"];
                    obj.isWorkerOnSite = returnData["isWorkerOnSite"] is DBNull ? (bool)false : (bool)returnData["isWorkerOnSite"];
                    obj.isWorkerOffSite = returnData["isWorkerOffSite"] is DBNull ? (bool)false : (bool)returnData["isWorkerOffSite"];
                    obj.isWorkerOnOffBoth = returnData["isWorkerOnOffBoth"] is DBNull ? (bool)false : (bool)returnData["isWorkerOnOffBoth"];
                    obj.isAccommodationFacilityToEmployees = returnData["isAccommodationFacilityToEmployees"] is DBNull ? (bool)false : (bool)returnData["isAccommodationFacilityToEmployees"];
                    obj.perOfManagementLiving = returnData["perOfManagementLiving"] is DBNull ? (decimal)0 : (decimal)returnData["perOfManagementLiving"];
                    obj.isManagementOffSite = returnData["isManagementOffSite"] is DBNull ? (bool)false : (bool)returnData["isManagementOffSite"];
                    obj.isManagementOnSite = returnData["isManagementOnSite"] is DBNull ? (bool)false : (bool)returnData["isManagementOnSite"];
                    obj.isManagementWorkerOnOffBoth = returnData["isManagementWorkerOnOffBoth"] is DBNull ? (bool)false : (bool)returnData["isManagementWorkerOnOffBoth"];
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
