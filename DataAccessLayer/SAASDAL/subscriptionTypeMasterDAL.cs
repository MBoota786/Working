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
   public class subscriptionTypeMasterDAL : SQLDataAccess
    {
        public int InsertSubscriptionTypeMaster(clsSubscriptionTypeMaster obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriodUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.timePeriodUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@SubscriptionDuration", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.SubscriptionDuration ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertSubscriptionTypeMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateSubscriptionTypeMaster(clsSubscriptionTypeMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value); 
                AddParamToSQLCmd(comm, "@timePeriodUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.timePeriodUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@SubscriptionDuration", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.SubscriptionDuration ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateSubscriptionTypeMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsSubscriptionTypeMaster> SelectAllSubscriptionTypeMaster(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllSubscriptionTypeMaster");
                SetDBName(dbName);
                List<clsSubscriptionTypeMaster> activeList = new List<clsSubscriptionTypeMaster>();
                TExecuteReaderCmd<clsSubscriptionTypeMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSubscriptionTypeMaster>, ref activeList);
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
        public List<clsSubscriptionTypeMaster> SelectSubscriptionTypeMasterById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSubscriptionTypeMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsSubscriptionTypeMaster> activeList = new List<clsSubscriptionTypeMaster>();
                TExecuteReaderCmd<clsSubscriptionTypeMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSubscriptionTypeMaster>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsSubscriptionTypeMaster> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsSubscriptionTypeMaster obj = new clsSubscriptionTypeMaster();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.timePeriodUnitId = returnData["timePeriodUnitId"] is DBNull ? (int)0 : (int)returnData["timePeriodUnitId"];
                    obj.SubscriptionDuration = returnData["SubscriptionDuration"] is DBNull ? (int)0 : (int)returnData["SubscriptionDuration"];
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
