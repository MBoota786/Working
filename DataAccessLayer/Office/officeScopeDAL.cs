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
   public class officeScopeDAL : SQLDataAccess
    {
        public int InsertOfficeScope(clsOfficeScope obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceScopeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isExclusive", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isExclusive ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeScope", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeScope(clsOfficeScope obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceScopeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isExclusive", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isExclusive ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeScope", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeScope> SelectAllOfficeScope(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeScope");

                List<clsOfficeScope> activeList = new List<clsOfficeScope>();
                TExecuteReaderCmd<clsOfficeScope>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeScope>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeScope>();
        }
        public List<clsOfficeScope> SelectOfficeScopeById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeScopeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeScope> activeList = new List<clsOfficeScope>();
                TExecuteReaderCmd<clsOfficeScope>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeScope>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeScope>();
        } 
        public List<clsOfficeScope> SelectOfficeScopeByOfficeId(int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeScopeByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsOfficeScope> activeList = new List<clsOfficeScope>();
                TExecuteReaderCmd<clsOfficeScope>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeScope>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeScope>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeScope> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeScope obj = new clsOfficeScope();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.serviceScopeId = returnData["serviceScopeId"] is DBNull ? (int)0 : (int)returnData["serviceScopeId"];
                    obj.isExclusive = returnData["isExclusive"] is DBNull ? (bool) false : (bool)returnData["isExclusive"];
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
