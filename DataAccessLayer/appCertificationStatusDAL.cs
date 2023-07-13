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
   public class appCertificationStatusDAL : SQLDataAccess
    {
        public int InsertAppCertificationStatus(clsAppCertificationStatus obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appCertificationStatus", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.appCertificationStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppCertificationStatus", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppCertificationStatus(clsAppCertificationStatus obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appCertificationStatus", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.appCertificationStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppCertificationStatus", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppCertificationStatus> SelectAllAppCertificationStatus(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppCertificationStatus");

                List<clsAppCertificationStatus> activeList = new List<clsAppCertificationStatus>();
                TExecuteReaderCmd<clsAppCertificationStatus>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppCertificationStatus>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppCertificationStatus>();
        }
        public List<clsAppCertificationStatus> SelectAppCertificationStatusById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppCertificationStatusById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppCertificationStatus> activeList = new List<clsAppCertificationStatus>();
                TExecuteReaderCmd<clsAppCertificationStatus>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppCertificationStatus>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppCertificationStatus>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppCertificationStatus> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppCertificationStatus obj = new clsAppCertificationStatus();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appCertificationStatus = returnData["appCertificationStatus"] is DBNull ? (string)string.Empty : (string)returnData["appCertificationStatus"];
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
