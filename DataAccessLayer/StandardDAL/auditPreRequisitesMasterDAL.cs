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
   public class auditPreRequisitesMasterDAL : SQLDataAccess
    {
        public int InsertAuditPreRequisitesMaster(clsAuditPreRequisitesMaster obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@preRequisitesName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.preRequisitesName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@docUploadRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.docUploadRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAnswerRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAnswerRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAuditPreRequisitesMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAuditPreRequisitesMaster(clsAuditPreRequisitesMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@preRequisitesName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.preRequisitesName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@docUploadRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.docUploadRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAnswerRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAnswerRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAuditPreRequisitesMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAuditPreRequisitesMaster> SelectAllAuditPreRequisitesMaster(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditPreRequisitesMaster");

                List<clsAuditPreRequisitesMaster> adressList = new List<clsAuditPreRequisitesMaster>();
                TExecuteReaderCmd<clsAuditPreRequisitesMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditPreRequisitesMaster>, ref adressList);
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
        public List<clsAuditPreRequisitesMaster> SelectAuditPreRequisitesMasterById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditPreRequisitesMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAuditPreRequisitesMaster> adressList = new List<clsAuditPreRequisitesMaster>();
                TExecuteReaderCmd<clsAuditPreRequisitesMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditPreRequisitesMaster>, ref adressList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditPreRequisitesMaster> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditPreRequisitesMaster obj = new clsAuditPreRequisitesMaster();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.preRequisitesName = returnData["preRequisitesName"] is DBNull ? (string)string.Empty : (string)returnData["preRequisitesName"];
                    obj.docUploadRequired = returnData["docUploadRequired"] is DBNull ? (bool)true : (bool)returnData["docUploadRequired"];
                    obj.isAnswerRequired = returnData["isAnswerRequired"] is DBNull ? (bool)true : (bool)returnData["isAnswerRequired"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
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
