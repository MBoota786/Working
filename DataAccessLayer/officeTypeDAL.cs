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
  public class officeTypeDAL : SQLDataAccess
    {
        public int InsertOfficeType(clsOfficeType ot)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ot.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTypeName", SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)ot.officeTypeName ?? DBNull.Value);
              //  AddParamToSQLCmd(comm, "@officeTypePrefix", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ot.officeTypePrefix ?? DBNull.Value);
              //  AddParamToSQLCmd(comm, "@officeTypeAlias", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ot.officeTypeAlias?? DBNull.Value);
             //   AddParamToSQLCmd(comm, "@initialOfficeTypeCount", SqlDbType.Int, 4 , ParameterDirection.Input, (object)ot.initialOfficeTypeCount?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ot.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ot.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ot.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeType", ot.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeType(clsOfficeType ot)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ot.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTypeName", SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)ot.officeTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTypePrefix", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ot.officeTypePrefix ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTypeAlias", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ot.officeTypeAlias ?? DBNull.Value);
              //  AddParamToSQLCmd(comm, "@initialOfficeTypeCount", SqlDbType.Int, 4, ParameterDirection.Input, (object)ot.initialOfficeTypeCount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ot.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ot.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ot.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeType", ot.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        } 
        public bool UpdateOfficeInitialCount(clsOfficeType ot)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ot.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@initialOfficeTypeCount", SqlDbType.Int, 4, ParameterDirection.Input, (object)ot.initialOfficeTypeCount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ot.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ot.modifiedBy ?? DBNull.Value);
                 ExecuteNonQueryCommand(comm, "spUpdateOfficeInitialCount", ot.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsOfficeType> SelectAllOfficeType(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeType");

                List<clsOfficeType> officeTypeList = new List<clsOfficeType>();
                TExecuteReaderCmd<clsOfficeType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeType>, ref officeTypeList);
                if (officeTypeList != null)
                {
                    return officeTypeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsOfficeType> SelectOfficeTypeById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeTypeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeType> officeTypeList = new List<clsOfficeType>();
                TExecuteReaderCmd<clsOfficeType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeType>, ref officeTypeList);
                if (officeTypeList != null)
                {
                    return officeTypeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeType> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeType obj = new clsOfficeType();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeTypeName = returnData["officeTypeName"] is DBNull ? (string)string.Empty : (string)returnData["officeTypeName"];
                    obj.officeTypePrefix = returnData["officeTypePrefix"] is DBNull ? (string)string.Empty : (string)returnData["officeTypePrefix"];
                    obj.officeTypeAlias = returnData["officeTypeAlias"] is DBNull ? (string)string.Empty : (string)returnData["officeTypeAlias"];
                    obj.initialOfficeTypeCount = returnData["initialOfficeTypeCount"] is DBNull ? (int) 0 : (int)returnData["initialOfficeTypeCount"];
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
