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
   public class officeStandardsDAL : SQLDataAccess
    {
        public int InsertOfficeStandards(clsOfficeStandards ls)
        {
            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeStandards", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public bool UpdateOfficeStandards(clsOfficeStandards ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeStandards", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeStandards> SelectAllOfficeStandards(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeStandards");

                List<clsOfficeStandards> activeList = new List<clsOfficeStandards>();
                TExecuteReaderCmd<clsOfficeStandards>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsOfficeStandards>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeStandards>();
        }
        public List<clsOfficeStandards> SelectOfficeStandardsById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeStandardsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeStandards> activeList = new List<clsOfficeStandards>();
                TExecuteReaderCmd<clsOfficeStandards>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsOfficeStandards>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeStandards>();
        }
        public List<clsOfficeStandards> SelectOfficeStandardsByOfficeId(int officeId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeStandardsByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsOfficeStandards> activeList = new List<clsOfficeStandards>();
                TExecuteReaderCmd<clsOfficeStandards>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsOfficeStandards>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeStandards>();
        }
        public void TGenerateSOFieldFromReaderactiveStatusList<T>(SqlDataReader returnData, ref List<clsOfficeStandards> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeStandards obj = new clsOfficeStandards();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.standardName = returnData["standardName"] is DBNull ? (string) string.Empty : (string)returnData["standardName"];
                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
                    
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
