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
   public class standardFeeCriteriaDAL : SQLDataAccess
    {
        public int InsertStandardFeeCriteria(clsStandardFeeCriteria obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@criteriaName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.criteriaName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForPercentage", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isForPercentage ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertStandardFeeCriteria", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStandardFeeCriteria(clsStandardFeeCriteria obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@criteriaName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.criteriaName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForPercentage", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isForPercentage ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateStandardFeeCriteria", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsStandardFeeCriteria> SelectAllStandardFeeCriteria(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardFeeCriteria");

                List<clsStandardFeeCriteria> adressList = new List<clsStandardFeeCriteria>();
                TExecuteReaderCmd<clsStandardFeeCriteria>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardFeeCriteria>, ref adressList);
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
        public List<clsStandardFeeCriteria> SelectStandardFeeCriteriaById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardFeeCriteriaById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsStandardFeeCriteria> adressList = new List<clsStandardFeeCriteria>();
                TExecuteReaderCmd<clsStandardFeeCriteria>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardFeeCriteria>, ref adressList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardFeeCriteria> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardFeeCriteria obj = new clsStandardFeeCriteria();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.criteriaName = returnData["criteriaName"] is DBNull ? (string)string.Empty : (string)returnData["criteriaName"];
                    obj.isForPercentage = returnData["isForPercentage"] is DBNull ? (bool)true : (bool)returnData["isForPercentage"];
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
