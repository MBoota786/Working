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
   public class packageStandardDAL : SQLDataAccess
    {
        public int InsertPackageStandard(clsPackageStandard obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@packageId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.packageId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertPackageStandard", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdatePackageStandard(clsPackageStandard obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@packageId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.packageId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdatePackageStandard", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsPackageStandard> SelectAllPackageStandard(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllPackageStandard");
                SetDBName(dbName);
                List<clsPackageStandard> activeList = new List<clsPackageStandard>();
                TExecuteReaderCmd<clsPackageStandard>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsPackageStandard>, ref activeList);
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
        public List<clsPackageStandard> SelectPackageStandardById(int id,string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectPackageStandardById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsPackageStandard> activeList = new List<clsPackageStandard>();
                TExecuteReaderCmd<clsPackageStandard>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsPackageStandard>, ref activeList);
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
        public List<clsPackageStandard> SelectPackageStandardByPackageId(int packageId, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectPackageStandardByPackageId");
                comand.Parameters.AddWithValue("@packageId", packageId);
                List<clsPackageStandard> activeList = new List<clsPackageStandard>();
                TExecuteReaderCmd<clsPackageStandard>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsPackageStandard>, ref activeList);
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
        public List<clsPackageStandard> SelectPackageStandardByCompanyId(int packageId, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectPackageStandardByCompanyId");
                comand.Parameters.AddWithValue("@packageId", packageId);
                List<clsPackageStandard> activeList = new List<clsPackageStandard>();
                TExecuteReaderCmd<clsPackageStandard>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsPackageStandard>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsPackageStandard>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsPackageStandard> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsPackageStandard obj = new clsPackageStandard();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.packageId = returnData["packageId"] is DBNull ? (int)0 : (int)returnData["packageId"];
                   
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    //Extra Columns In Reader
                    if (ColumnExists(returnData, "standardName"))
                    {
                        obj.standardName = returnData["standardName"] is DBNull ? (string)string.Empty : (string)returnData["standardName"];
                    }

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
