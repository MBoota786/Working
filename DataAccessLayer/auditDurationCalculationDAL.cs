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
  public class auditDurationCalculationDAL : SQLDataAccess
    {
        public int InsertAuditDurationCalculation(clsAuditDurationCalculation ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardSetupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.standardSetupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditDurationParameters", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.auditDurationParameters ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spInsertAuditDurationCalculation");
               Id= ExecuteInsertCommandReturnId(comm, "spInsertAuditDurationCalculation", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateDurationCalculation(clsAuditDurationCalculation ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardSetupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.standardSetupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditDurationParameters", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.auditDurationParameters ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spUpdateDurationCalculation");
                ExecuteNonQueryCommand(comm, "spUpdateDurationCalculation", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAuditDurationCalculation> SelectAllAuditDurationCalculation()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditDurationCalculation");

                List<clsAuditDurationCalculation> activeList = new List<clsAuditDurationCalculation>();
                TExecuteReaderCmd<clsAuditDurationCalculation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditDurationCalculation>, ref activeList);
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
        public List<clsAuditDurationCalculation> SelectAuditDurationCalculationById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditDurationCalculationById");
                comand.Parameters.AddWithValue("@id", id);

                List<clsAuditDurationCalculation> activeList = new List<clsAuditDurationCalculation>();
                TExecuteReaderCmd<clsAuditDurationCalculation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditDurationCalculation>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditDurationCalculation> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditDurationCalculation obj = new clsAuditDurationCalculation();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.standardSetupId = returnData["standardSetupId"] is DBNull ? (int)0 : (int)returnData["standardSetupId"];
                    obj.auditDurationParameters = returnData["auditDurationParameters"] is DBNull ? (string)string.Empty : (string)returnData["auditDurationParameters"];
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
