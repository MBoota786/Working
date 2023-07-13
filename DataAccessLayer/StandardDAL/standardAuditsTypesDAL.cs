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
   public class standardAuditsTypesDAL : SQLDataAccess
    {
        public int InsertStandardAuditTypes(clsStandardAuditsTypes obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditAnnouncementTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditAnnouncementTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriodUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.timePeriodUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriod", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.timePeriod ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertStandardAuditTypes", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStandardAuditTypes(clsStandardAuditsTypes obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditAnnouncementTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditAnnouncementTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriodUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.timePeriodUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriod", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.timePeriod ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateStandardAuditTypes", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsStandardAuditsTypes> SelectAllStandardAuditsTypes(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardAuditsTypes");

                List<clsStandardAuditsTypes> adressList = new List<clsStandardAuditsTypes>();
                TExecuteReaderCmd<clsStandardAuditsTypes>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardAuditsTypes>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsStandardAuditsTypes> SelectStandardAuditsTypesById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardAuditsTypesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsStandardAuditsTypes> adressList = new List<clsStandardAuditsTypes>();
                TExecuteReaderCmd<clsStandardAuditsTypes>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardAuditsTypes>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsStandardAuditsTypes> SelectStandardAuditsTypesByAccreditationStandardId(int accreditationStandardId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardAuditsTypesByAccreditationStandardId");
                comand.Parameters.AddWithValue("@accreditationStandardId", accreditationStandardId);
                List<clsStandardAuditsTypes> adressList = new List<clsStandardAuditsTypes>();
                TExecuteReaderCmd<clsStandardAuditsTypes>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardAuditsTypes>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardAuditsTypes> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardAuditsTypes obj = new clsStandardAuditsTypes();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.auditAnnouncementTypeId = returnData["auditAnnouncementTypeId"] is DBNull ? (int)0 : (int)returnData["auditAnnouncementTypeId"];
                    obj.timePeriodUnitId = returnData["timePeriodUnitId"] is DBNull ? (int)0 : (int)returnData["timePeriodUnitId"];
                    obj.timePeriod = returnData["timePeriod"] is DBNull ? (int)0 : (int)returnData["timePeriod"];
                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    if (ColumnExists(returnData, "auditTypeName"))
                    {
                        obj.auditTypeName = returnData["auditTypeName"] is DBNull ? (string) string.Empty : (string)returnData["auditTypeName"];

                    }
                    activeEmail.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
