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
   public class servicesDAL : SQLDataAccess
    {
        public int InsertServices(clsServices obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@costTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.costTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.serviceName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceDetail", SqlDbType.NVarChar, 500,ParameterDirection.Input, (object)obj.serviceDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertServices", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateServices(clsServices obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@costTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.costTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.serviceName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceDetail", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.serviceDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateServices", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsServices> SelectAllServices(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllServices");
                SetDBName(dbName);
                List<clsServices> activeList = new List<clsServices>();
                TExecuteReaderCmd<clsServices>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsServices>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsServices>();
        }
        public List<clsServices> SelectServicesById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectServicesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsServices> activeList = new List<clsServices>();
                TExecuteReaderCmd<clsServices>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsServices>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsServices>();
        } 
        public List<clsServices> SelectServicesByServiceTypeId(int serviceTypeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectServicesByServiceTypeId");
                comand.Parameters.AddWithValue("@serviceTypeId", serviceTypeId);
                List<clsServices> activeList = new List<clsServices>();
                TExecuteReaderCmd<clsServices>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsServices>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsServices>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsServices> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsServices obj = new clsServices();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.costTypeId = returnData["costTypeId"] is DBNull ? (int)0 : (int)returnData["costTypeId"];
                    obj.serviceTypeId = returnData["serviceTypeId"] is DBNull ? (int)0 : (int)returnData["serviceTypeId"];
                    obj.serviceName = returnData["serviceName"] is DBNull ? (string)string.Empty : (string)returnData["serviceName"];
                    obj.serviceDetail = returnData["serviceDetail"] is DBNull ? (string)string.Empty : (string)returnData["serviceDetail"];
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
