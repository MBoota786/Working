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
   public class checkListDAL : SQLDataAccess
    {
        public int InsertCheckList(clsCheckList obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardReqCheckListId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardReqCheckListId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@checkListSectionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.checkListSectionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@checkPointName", SqlDbType.VarChar, 50, ParameterDirection.Input, (object)obj.checkPointName ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
               Id =  ExecuteInsertCommandReturnId(comm, "spInsertCheckList", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateCheckList(clsCheckList obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardReqCheckListId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardReqCheckListId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@checkListSectionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.checkListSectionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@checkListType", SqlDbType.VarChar, 50, ParameterDirection.Input, (object)obj.checkPointName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateCheckList", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsCheckList> SelectAllCheckList(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCheckList");

                List<clsCheckList> activeList = new List<clsCheckList>();
                TExecuteReaderCmd<clsCheckList>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsCheckList>, ref activeList);
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
        public List<clsCheckList> SelectAllCheckListById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCheckListById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsCheckList> activeList = new List<clsCheckList>();
                TExecuteReaderCmd<clsCheckList>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsCheckList>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsCheckList> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsCheckList obj = new clsCheckList();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.standardReqCheckListId = returnData["standardReqCheckListId"] is DBNull ? (int)0 : (int)returnData["standardReqCheckListId"];
                    obj.checkListSectionId = returnData["checkListSectionId"] is DBNull ? (int)0 : (int)returnData["checkListSectionId"];
                    obj.checkPointName = returnData["checkPointName"] is DBNull ? (string)string.Empty : (string)returnData["checkPointName"];
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
