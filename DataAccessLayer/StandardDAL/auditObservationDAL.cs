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
   public class auditObservationDAL : SQLDataAccess
    {
        public int InsertAuditObservation(clsAuditObservation obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditObservationTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditObservationTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clouserRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.clouserRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clouserDuration", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clouserDuration ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAuditObservation", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAuditObservation(clsAuditObservation obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditObservationTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditObservationTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clouserRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.clouserRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clouserDuration", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clouserDuration ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAuditObservation", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAuditObservation> SelectAllAuditObservation(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditObservation");

                List<clsAuditObservation> activeList = new List<clsAuditObservation>();
                TExecuteReaderCmd<clsAuditObservation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditObservation>, ref activeList);
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
        public List<clsAuditObservation> SelectAuditObservationById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditObservationById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAuditObservation> activeList = new List<clsAuditObservation>();
                TExecuteReaderCmd<clsAuditObservation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditObservation>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditObservation> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditObservation obj = new clsAuditObservation();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationBodyStandardId = returnData["accreditationBodyStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationBodyStandardId"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.auditObservationTypeId = returnData["auditObservationTypeId"] is DBNull ? (int)0 : (int)returnData["auditObservationTypeId"];
                    obj.clouserRequired = returnData["clouserDuration"] is DBNull ? (bool) false : (bool)returnData["clouserDuration"];
                    obj.clouserDuration = returnData["clouserDuration"] is DBNull ? (int)0 : (int)returnData["clouserDuration"];
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
