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
   public class accrIndustrialCodeTypeDAL : SQLDataAccess
    {
        public int InsertAccrIndustrialCodeType(clsAccrIndustrialCodeType obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrIndustrialCodeType", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrIndustrialCodeType ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicableFromDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.applicableFromDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccrIndustrialCodeType", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccrIndustrialCodeType(clsAccrIndustrialCodeType obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrIndustrialCodeType", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrIndustrialCodeType ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicableFromDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.applicableFromDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccrIndustrialCodeType", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccrIndustrialCodeType> SelectAllAccrIndustrialCodeType(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccrIndustrialCodeType");

                List<clsAccrIndustrialCodeType> activeList = new List<clsAccrIndustrialCodeType>();
                TExecuteReaderCmd<clsAccrIndustrialCodeType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrIndustrialCodeType>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrIndustrialCodeType>();
        }
        public List<clsAccrIndustrialCodeType> SelectAccrIndustrialCodeTypeById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrIndustrialCodeTypeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccrIndustrialCodeType> activeList = new List<clsAccrIndustrialCodeType>();
                TExecuteReaderCmd<clsAccrIndustrialCodeType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrIndustrialCodeType>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrIndustrialCodeType>();
        }     
        public List<clsAccrIndustrialCodeType> SelectAccrIndustrialCodeTypeByName(string accrIndustrialCodeType, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrIndustrialCodeTypeById");
                comand.Parameters.AddWithValue("@accrIndustrialCodeType", accrIndustrialCodeType);
                List<clsAccrIndustrialCodeType> activeList = new List<clsAccrIndustrialCodeType>();
                TExecuteReaderCmd<clsAccrIndustrialCodeType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrIndustrialCodeType>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrIndustrialCodeType>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccrIndustrialCodeType> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccrIndustrialCodeType obj = new clsAccrIndustrialCodeType();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accrIndustrialCodeType= returnData["accrIndustrialCodeType"] is DBNull ? (string)string.Empty : (string)returnData["accrIndustrialCodeType"];
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
