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
   public class standardRightsDAL : SQLDataAccess
    {
        public int InsertStandardRights(clsStandardRights obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardRightPointId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardRightPointId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertStandardRights", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStandardRights(clsStandardRights obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardRightPointId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardRightPointId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateStandardRights", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsStandardRights> SelectAllStandardRights(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardRights");

                List<clsStandardRights> activeList = new List<clsStandardRights>();
                TExecuteReaderCmd<clsStandardRights>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardRights>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardRights>();
        }
        public List<clsStandardRights> SelectStandardRightsById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardRightsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsStandardRights> activeList = new List<clsStandardRights>();
                TExecuteReaderCmd<clsStandardRights>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardRights>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardRights>();
        }  
        public List<clsStandardRights> SelectStandardRightsByOfficeId(int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardRightsByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsStandardRights> activeList = new List<clsStandardRights>();
                TExecuteReaderCmd<clsStandardRights>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardRights>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardRights>();
        } 
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardRights> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardRights obj = new clsStandardRights();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.standardRightPointId = returnData["standardRightPointId"] is DBNull ? (int)0 : (int)returnData["standardRightPointId"];
                    obj.standardRightPoint = returnData["standardRightPoint"] is DBNull ? (string) string.Empty : (string)returnData["standardRightPoint"];
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
