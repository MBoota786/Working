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
   public class nonConformatiesDAL : SQLDataAccess
    {
        public int InsertNonConformaties(clsNonConformaties obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nonConformitiesTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.nonConformitiesTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nonConformatiesClosureRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.nonConformatiesClosureRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nonConformatiesClosureDuration", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.nonConformatiesClosureDuration ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nonConformatiesFollowUpAudit", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.nonConformatiesFollowUpAudit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertNonConformaties", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateNonConformaties(clsNonConformaties obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nonConformitiesTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.nonConformitiesTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nonConformatiesClosureRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.nonConformatiesClosureRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nonConformatiesClosureDuration", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.nonConformatiesClosureDuration ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nonConformatiesFollowUpAudit", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.nonConformatiesFollowUpAudit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateNonConformaties", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsNonConformaties> SelectAllNonConformaties()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllNonConformaties");

                List<clsNonConformaties> activeList = new List<clsNonConformaties>();
                TExecuteReaderCmd<clsNonConformaties>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsNonConformaties>, ref activeList);
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
        public List<clsNonConformaties> SelectNonConformatiesById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectNonConformatiesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsNonConformaties> activeList = new List<clsNonConformaties>();
                TExecuteReaderCmd<clsNonConformaties>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsNonConformaties>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsNonConformaties> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsNonConformaties obj = new clsNonConformaties();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.nonConformitiesTypeId = returnData["nonConformitiesTypeId"] is DBNull ? (int)0 : (int)returnData["nonConformitiesTypeId"];
                    obj.nonConformatiesClosureRequired = returnData["nonConformatiesClosureRequired"] is DBNull ? (bool)false : (bool)returnData["nonConformatiesClosureRequired"];
                    obj.nonConformatiesClosureDuration = returnData["nonConformatiesClosureDuration"] is DBNull ? (string)string.Empty : (string)returnData["nonConformatiesClosureDuration"];
                    obj.nonConformatiesFollowUpAudit = returnData["nonConformatiesFollowUpAudit"] is DBNull ? (string)string.Empty : (string)returnData["nonConformatiesFollowUpAudit"];
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
