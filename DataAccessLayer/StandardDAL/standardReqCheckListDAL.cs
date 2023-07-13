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
   public class standardReqCheckListDAL : SQLDataAccess
    {
        public int InsertStandardReqCheckList(clsStandardReqCheckList obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@checkListTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.checkListTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@docUploadRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.docUploadRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditCheckListPath", SqlDbType.NVarChar, 250 , ParameterDirection.Input, (object)obj.auditCheckListPath ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
              Id =  ExecuteInsertCommandReturnId(comm, "spInsertStandardReqCheckList", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStandardReqCheckList(clsStandardReqCheckList obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@checkListTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.checkListTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@docUploadRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.docUploadRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditCheckListPath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.auditCheckListPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateStandardReqCheckList", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsStandardReqCheckList> SelectAllStandardReqCheckList(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCheckListSection");

                List<clsStandardReqCheckList> activeList = new List<clsStandardReqCheckList>();
                TExecuteReaderCmd<clsStandardReqCheckList>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardReqCheckList>, ref activeList);
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
        public List<clsStandardReqCheckList> SelectStandardReqCheckListById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectCheckListSectionById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsStandardReqCheckList> activeList = new List<clsStandardReqCheckList>();
                TExecuteReaderCmd<clsStandardReqCheckList>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardReqCheckList>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardReqCheckList> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardReqCheckList obj = new clsStandardReqCheckList();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationBodyStandardId = returnData["standardReqCheckListId"] is DBNull ? (int)0 : (int)returnData["standardReqCheckListId"];
                    obj.auditTypeId = returnData["standardReqCheckListId"] is DBNull ? (int)0 : (int)returnData["standardReqCheckListId"];
                    obj.checkListTypeId = returnData["standardReqCheckListId"] is DBNull ? (int)0 : (int)returnData["standardReqCheckListId"];
                    obj.isRequired = returnData["isRequired"] is DBNull ? (bool) false : (bool)returnData["isRequired"];
                    obj.docUploadRequired = returnData["docUploadRequired"] is DBNull ? (bool) false : (bool)returnData["docUploadRequired"];
                    obj.auditCheckListPath = returnData["auditCheckListPath"] is DBNull ? (string)string.Empty : (string)returnData["auditCheckListPath"];
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
