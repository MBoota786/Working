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
   public class accrCountryScopeMapDAL : SQLDataAccess
    {
        public int InsertAccrCountryScopeMap(clsAccrCountryScopeMap obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccrCountryScopeMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccrCountryScopeMap(clsAccrCountryScopeMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccrCountryScopeMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccrCountryScopeMap> SelectAllAccrCountryScopeMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccrCountryScopeMap");

                List<clsAccrCountryScopeMap> activeList = new List<clsAccrCountryScopeMap>();
                TExecuteReaderCmd<clsAccrCountryScopeMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrCountryScopeMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrCountryScopeMap>();
        }
        public List<clsAccrCountryScopeMap> SelectAccrCountryScopeMapById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrCountryScopeMapById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccrCountryScopeMap> activeList = new List<clsAccrCountryScopeMap>();
                TExecuteReaderCmd<clsAccrCountryScopeMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrCountryScopeMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrCountryScopeMap>();
        }
        public List<clsAccrCountryScopeMap> spSelectAccrCountryScopeMapByAccreditationBodyStandardId(int accreditationBodyStandardId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrCountryScopeMapByAccreditationBodyStandardId");
                comand.Parameters.AddWithValue("@accreditationBodyStandardId", accreditationBodyStandardId);
                List<clsAccrCountryScopeMap> activeList = new List<clsAccrCountryScopeMap>();
                TExecuteReaderCmd<clsAccrCountryScopeMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrCountryScopeMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrCountryScopeMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccrCountryScopeMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccrCountryScopeMap obj = new clsAccrCountryScopeMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationBodyStandardId = returnData["accreditationBodyStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationBodyStandardId"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.countryName = returnData["countryName"] is DBNull ? (string) string.Empty : (string)returnData["countryName"];
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
        public bool DeleteAccrCountryScopeMapByAccreditationBodyStandardId(int accreditationBodyStandardId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)accreditationBodyStandardId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteAccrCountryScopeMapByAccreditationBodyStandardId", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
