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
   public class accrBodyStandardDurationDAL : SQLDataAccess
    {
        public int InsertAccrStandardDuration(clsAccrBodyStandardDuration obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accrBodyStandardId ?? DBNull.Value);
                 AddParamToSQLCmd(comm, "@accrDurationFrom", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.accrDurationFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrDurationTo", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.accrDurationTo ?? DBNull.Value);
                  AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccrStandardDuration", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccrStandardDuration(clsAccrBodyStandardDuration obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accrBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrDurationFrom", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.accrDurationFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrDurationTo", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.accrDurationTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccrStandardDuration", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccrBodyStandardDuration> SelectAllAccrBodyStandardDuration(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccrBodyStandardDuration");

                List<clsAccrBodyStandardDuration> activeList = new List<clsAccrBodyStandardDuration>();
                TExecuteReaderCmd<clsAccrBodyStandardDuration>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrBodyStandardDuration>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrBodyStandardDuration>();
        }
        public List<clsAccrBodyStandardDuration> SelectAccrBodyStandardDurationById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrBodyStandardDurationById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccrBodyStandardDuration> activeList = new List<clsAccrBodyStandardDuration>();
                TExecuteReaderCmd<clsAccrBodyStandardDuration>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrBodyStandardDuration>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrBodyStandardDuration>();
        }
        public List<clsAccrBodyStandardDuration> SelectAccrBodyStandardDurationByAccrBodyStandardId(int accrBodyStandardId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrBodyStandardDurationByAccrBodyStandardId");
                comand.Parameters.AddWithValue("@accrBodyStandardId", accrBodyStandardId);
                List<clsAccrBodyStandardDuration> activeList = new List<clsAccrBodyStandardDuration>();
                TExecuteReaderCmd<clsAccrBodyStandardDuration>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrBodyStandardDuration>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrBodyStandardDuration>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccrBodyStandardDuration> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccrBodyStandardDuration obj = new clsAccrBodyStandardDuration();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accrBodyStandardId = returnData["accrBodyStandardId"] is DBNull ? (int)0 : (int)returnData["accrBodyStandardId"];
                    obj.accrDurationFrom= returnData["accrDurationFrom"] is DBNull ? (DateTime?)null : (DateTime)returnData["accrDurationFrom"];  
                    obj.accrDurationTo= returnData["accrDurationTo"] is DBNull ? (DateTime?)null : (DateTime)returnData["accrDurationTo"];  
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
