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
   public class designationDAL : SQLDataAccess
    {
        public int InsertDesignation(clsDesignation ls)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@designationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.designationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertDesignation", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateDesignation(clsDesignation ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@designationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.designationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateDesignation", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsDesignation> SelectAllDesignation(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllDesignation");

                List<clsDesignation> desinationList = new List<clsDesignation>();
                TExecuteReaderCmd<clsDesignation>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsDesignation>, ref desinationList);
                if (desinationList != null)
                {
                    return desinationList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsDesignation> SelectDesignationById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectDesignationById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsDesignation> designationList = new List<clsDesignation>();
                TExecuteReaderCmd<clsDesignation>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsDesignation>, ref designationList);
                if (designationList != null)
                {
                    return designationList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveStatusList<T>(SqlDataReader returnData, ref List<clsDesignation> activeLegalStatus)
        {
            try
            {
                while (returnData.Read())
                {
                    clsDesignation obj = new clsDesignation();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.designationName = returnData["designationName"] is DBNull ? (string)string.Empty : (string)returnData["designationName"];
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
        public bool IsDesignationExist(string designationName, string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@designationName", designationName);
                return IsRecordExistCheck(cmd, "spIsDesignationExist", dbName);
            }
        }
    }
}
