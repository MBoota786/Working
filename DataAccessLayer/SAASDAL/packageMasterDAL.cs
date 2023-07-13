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
   public class packageMasterDAL : SQLDataAccess
    {
        public int InsertPackageMaster(clsPackageMaster obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfStandard", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfStandard ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfOffice", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfUser", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfUser ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@validityDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.validityDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@startDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.startDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertPackageMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdatePackageMaster(clsPackageMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfStandard", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfStandard ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfOffice", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfUser", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfUser ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@validityDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.validityDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@startDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.startDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdatePackageMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsPackageMaster> SelectAllPackageMaster(string DBName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(DBName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllPackageMaster");
                List<clsPackageMaster> activeList = new List<clsPackageMaster>();
                TExecuteReaderCmd<clsPackageMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsPackageMaster>, ref activeList);
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
        public List<clsPackageMaster> SelectPackageMasterById(int id,string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectPackageMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsPackageMaster> activeList = new List<clsPackageMaster>();
                TExecuteReaderCmd<clsPackageMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsPackageMaster>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsPackageMaster> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsPackageMaster obj = new clsPackageMaster();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.packageName = returnData["packageName"] is DBNull ? (string)string.Empty : (string)returnData["packageName"];
                    obj.noOfStandard = returnData["noOfStandard"] is DBNull ? (int)0 : (int)returnData["noOfStandard"];
                    obj.noOfOffice = returnData["noOfOffice"] is DBNull ? (int)0 : (int)returnData["noOfOffice"];
                    obj.noOfUser = returnData["noOfUser"] is DBNull ? (int)0 : (int)returnData["noOfUser"];
                    obj.validityDate = returnData["validityDate"] is DBNull ? (DateTime?)null : (DateTime)returnData["validityDate"];
                    obj.startDate = returnData["startDate"] is DBNull ? (DateTime?)null : (DateTime)returnData["startDate"];
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
