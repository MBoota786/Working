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
   public class taxTermDAL : SQLDataAccess
    {
        public int InsertTaxTerm(clsTaxTerm obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxTermName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.taxTermName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAdd", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAdd ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isMinus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isMinus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertTaxTerm", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateTaxTerm(clsTaxTerm obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxTermName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.taxTermName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAdd", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAdd ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isMinus", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isMinus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateTaxTerm", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsTaxTerm> SelectAllTaxTerm(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllTaxTerm");

                List<clsTaxTerm> activeList = new List<clsTaxTerm>();
                TExecuteReaderCmd<clsTaxTerm>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsTaxTerm>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsTaxTerm>();
        }
        public List<clsTaxTerm> SelectTaxTermById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectTaxTermById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsTaxTerm> activeList = new List<clsTaxTerm>();
                TExecuteReaderCmd<clsTaxTerm>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsTaxTerm>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsTaxTerm>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsTaxTerm> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsTaxTerm obj = new clsTaxTerm();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.taxTermName = returnData["taxTermName"] is DBNull ? (string)string.Empty : (string)returnData["taxTermName"];
                    obj.isAdd = returnData["isAdd"] is DBNull ? (bool)true : (bool)returnData["isAdd"];
                    obj.isMinus = returnData["isMinus"] is DBNull ? (bool)true : (bool)returnData["isMinus"];
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
