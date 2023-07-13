﻿using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class clauseTypeDAL : SQLDataAccess
    {
        public int InsertClauseType(clsClauseType obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clauseTypeName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clauseTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClauseType", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClauseType(clsClauseType obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clauseTypeName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.clauseTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClauseType", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsClauseType> SelectAllClauseType(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClauseType");

                List<clsClauseType> activeList = new List<clsClauseType>();
                TExecuteReaderCmd<clsClauseType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClauseType>, ref activeList);
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
        public List<clsClauseType> SelectClauseTypeById(int id, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClauseTypeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClauseType> activeList = new List<clsClauseType>();
                TExecuteReaderCmd<clsClauseType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClauseType>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClauseType> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClauseType obj = new clsClauseType();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clauseTypeName = returnData["clauseTypeName"] is DBNull ? (string)string.Empty : (string)returnData["clauseTypeName"];
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
