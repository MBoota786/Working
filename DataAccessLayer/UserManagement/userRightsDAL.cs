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
   public class userRightsDAL : SQLDataAccess
    {
        public int InsertUserRights(clsUserRights obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@moduleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.moduleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userLoginId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.userLoginId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightEnter", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightEnter ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightVerify", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightVerify ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightCheck", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightCheck ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightApprove", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightApprove ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightPrint", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightPrint ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightEdit", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightEdit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightDelete", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightDelete ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightExtend", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightExtend ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertUserRights", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateUserRights(clsUserRights obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@moduleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.moduleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userLoginId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.userLoginId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightEnter", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightEnter ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightVerify", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightVerify ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightCheck", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightCheck ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightApprove", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightApprove ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightPrint", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightPrint ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightEdit", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightEdit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightDelete", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightDelete ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@rightExtend", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.rightExtend ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateUserRights", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsUserRights> SelectAllUserRights(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllUserRights");

                List<clsUserRights> activeList = new List<clsUserRights>();
                TExecuteReaderCmd<clsUserRights>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsUserRights>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsUserRights>();
        }
        public List<clsUserRights> SelectUserRightsById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectUserRightsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsUserRights> activeList = new List<clsUserRights>();
                TExecuteReaderCmd<clsUserRights>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsUserRights>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsUserRights>();
        }
        public List<clsUserRights> SelectUserRightsByUserLoginId(int userLoginId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectUserRightsByUserLoginId");
                comand.Parameters.AddWithValue("@userLoginId", userLoginId);
                List<clsUserRights> activeList = new List<clsUserRights>();
                TExecuteReaderCmd<clsUserRights>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsUserRights>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsUserRights>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsUserRights> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsUserRights obj = new clsUserRights();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.moduleId = returnData["moduleId"] is DBNull ? (int)0 : (int)returnData["moduleId"];
                    obj.userLoginId = returnData["userLoginId"] is DBNull ? (int)0 : (int)returnData["userLoginId"];
                    obj.rightEnter = returnData["rightEnter"] is DBNull ? (bool)false : (bool)returnData["rightEnter"];
                    obj.rightVerify = returnData["rightVerify"] is DBNull ? (bool)false : (bool)returnData["rightVerify"];
                    obj.rightCheck = returnData["rightCheck"] is DBNull ? (bool)false : (bool)returnData["rightCheck"];
                    obj.rightApprove = returnData["rightApprove"] is DBNull ? (bool)false : (bool)returnData["rightApprove"];
                    obj.rightPrint = returnData["rightPrint"] is DBNull ? (bool)false : (bool)returnData["rightPrint"];
                    obj.rightDelete = returnData["rightDelete"] is DBNull ? (bool)false : (bool)returnData["rightDelete"];
                    obj.rightEdit = returnData["rightEdit"] is DBNull ? (bool)false : (bool)returnData["rightEdit"];
                    obj.rightExtend = returnData["rightExtend"] is DBNull ? (bool)false : (bool)returnData["rightExtend "];
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
