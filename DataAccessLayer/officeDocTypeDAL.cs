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
  public  class officeDocTypeDAL : SQLDataAccess
    {
        public int InsertOfficeDocType(clsOfficeDocType ls)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@docTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.docTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeDocType", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeDocType(clsOfficeDocType ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@docTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.docTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeDocType", ls.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsOfficeDocType> SelectAllOfficeDocType(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeDocType");

                List<clsOfficeDocType> officeDocTypeList = new List<clsOfficeDocType>();
                TExecuteReaderCmd<clsOfficeDocType>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsOfficeDocType>, ref officeDocTypeList);
                if (officeDocTypeList != null)
                {
                    return officeDocTypeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsOfficeDocType> SelectOfficeDocTypesById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeDocTypeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeDocType> officeDocTypeList = new List<clsOfficeDocType>();
                TExecuteReaderCmd<clsOfficeDocType>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsOfficeDocType>, ref officeDocTypeList);
                if (officeDocTypeList != null)
                {
                    return officeDocTypeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveStatusList<T>(SqlDataReader returnData, ref List<clsOfficeDocType> activeLegalStatus)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeDocType obj = new clsOfficeDocType();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.docTypeName = returnData["docTypeName"] is DBNull ? (string)string.Empty : (string)returnData["docTypeName"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    activeLegalStatus.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
