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
   public class checkListSectionDAL : SQLDataAccess
    {
        public int InsertCheckListSection(clsCheckListSection obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardReqCheckListId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardReqCheckListId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@checkListSectionName", SqlDbType.VarChar, 100 , ParameterDirection.Input, (object)obj.checkListSectionName ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
              Id =  ExecuteInsertCommandReturnId(comm, "spInsertCheckListSection", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateCheckListSection(clsCheckListSection obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardReqCheckListId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardReqCheckListId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@checkListSectionName", SqlDbType.VarChar, 100, ParameterDirection.Input, (object)obj.checkListSectionName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateCheckListSection", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsCheckListSection> SelectAllCheckListSection(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCheckListSection");

                List<clsCheckListSection> activeList = new List<clsCheckListSection>();
                TExecuteReaderCmd<clsCheckListSection>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsCheckListSection>, ref activeList);
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
        public List<clsCheckListSection> SelectCheckListSectionById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectCheckListSectionById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsCheckListSection> activeList = new List<clsCheckListSection>();
                TExecuteReaderCmd<clsCheckListSection>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsCheckListSection>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsCheckListSection> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsCheckListSection obj = new clsCheckListSection();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.standardReqCheckListId = returnData["standardReqCheckListId"] is DBNull ? (int)0 : (int)returnData["standardReqCheckListId"];
                    obj.checkListSectionName = returnData["checkListSectionName"] is DBNull ? (string)string.Empty : (string)returnData["checkListSectionName"];
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
