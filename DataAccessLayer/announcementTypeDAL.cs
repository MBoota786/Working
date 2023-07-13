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
  public class announcementTypeDAL : SQLDataAccess
    {
        public int InsertAnnouncementType(clsAnnouncementType ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@announcementTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.announcementTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDateRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isDateRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isTimeRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isTimeRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAnnouncementType", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAnnouncementType(clsAnnouncementType ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@announcementTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.announcementTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDateRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isDateRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isTimeRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isTimeRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAnnouncementType", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAnnouncementType> SelectAllAnouncementType(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAnouncementType");
                SetDBName(dbName);
                List<clsAnnouncementType> activeList = new List<clsAnnouncementType>();
                TExecuteReaderCmd<clsAnnouncementType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditCycle>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAnnouncementType>();
        }
        public List<clsAnnouncementType> SelectAnouncementTypeById(int id, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAnouncementTypeById");
                comand.Parameters.AddWithValue("@id", id);
                SetDBName(dbName);
                List<clsAnnouncementType> activeList = new List<clsAnnouncementType>();
                TExecuteReaderCmd<clsAnnouncementType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditCycle>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAnnouncementType>();
        }     
        public List<clsAnnouncementType> SelectAllAnouncementTypeByAccreditationStandardIdAndAuditTypeId(int accreditationStandardId,int auditTypeId, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAnouncementTypeByAccreditationStandardIdAndAuditTypeId");
                comand.Parameters.AddWithValue("@accreditationStandardId", accreditationStandardId);
                comand.Parameters.AddWithValue("@auditTypeId", auditTypeId);
                SetDBName(dbName);
                List<clsAnnouncementType> activeList = new List<clsAnnouncementType>();
                TExecuteReaderCmd<clsAnnouncementType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditCycle>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAnnouncementType>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAnnouncementType> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAnnouncementType obj = new clsAnnouncementType();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.announcementTypeName = returnData["announcementTypeName"] is DBNull ? (string)string.Empty : (string)returnData["announcementTypeName"];
                  
                    obj.isDateRequired = returnData["isDateRequired"] is DBNull ? (bool)true : (bool)returnData["isDateRequired"];
                    obj.isTimeRequired = returnData["isTimeRequired"] is DBNull ? (bool)true : (bool)returnData["isTimeRequired"];
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
