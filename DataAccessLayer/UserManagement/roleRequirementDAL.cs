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
   public class roleRequirementDAL : SQLDataAccess
    {
        public int InsertRoleRequirement(clsRoleRequirement obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.roleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requirementName", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.requirementName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDocumentUploadRequired ", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDocumentUploadRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertRoleRequirement", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateRoleRequirement(clsRoleRequirement obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.roleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requirementName", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.requirementName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDocumentUploadRequired ", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDocumentUploadRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateRoleRequirement", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsRoleRequirement> SelectAllRoleRequirement(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllRoleRequirement");

                List<clsRoleRequirement> activeList = new List<clsRoleRequirement>();
                TExecuteReaderCmd<clsRoleRequirement>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRoleRequirement>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRoleRequirement>();
        }
        public List<clsRoleRequirement> SelectRoleRequirementById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectRoleRequirementById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsRoleRequirement> activeList = new List<clsRoleRequirement>();
                TExecuteReaderCmd<clsRoleRequirement>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRoleRequirement>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRoleRequirement>();
        }  
        public List<clsRoleRequirement> SelectRoleRequirementByRoleId(int roleId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectRoleRequirementByRoleId");
                comand.Parameters.AddWithValue("@roleId", roleId);
                List<clsRoleRequirement> activeList = new List<clsRoleRequirement>();
                TExecuteReaderCmd<clsRoleRequirement>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRoleRequirement>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRoleRequirement>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsRoleRequirement> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsRoleRequirement obj = new clsRoleRequirement();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.roleId = returnData["roleId"] is DBNull ? (int)0 : (int)returnData["roleId"];
                    obj.accreditationBodyId = returnData["accreditationBodyId"] is DBNull ? (int)0 : (int)returnData["accreditationBodyId"];
                    obj.roleName = returnData["roleName"] is DBNull ? (string)string.Empty : (string)returnData["roleName"];
                    obj.accreditationName = returnData["accreditationName"] is DBNull ? (string)string.Empty : (string)returnData["accreditationName"];
                    obj.isDocumentUploadRequired = returnData["isDocumentUploadRequired"] is DBNull ? (bool)true : (bool)returnData["isDocumentUploadRequired"];
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
