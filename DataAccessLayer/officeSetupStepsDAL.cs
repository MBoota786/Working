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
  public  class officeSetupStepsDAL : SQLDataAccess
    {
        public int InsertOfficeSetupSteps(clsOfficeSetupSteps ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stepId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.stepId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stepStatusId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.stepStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stepDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.stepDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stepTime", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.stepTime ?? DBNull.Value);
               Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeSetupSteps", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeSetupSteps(clsOfficeSetupSteps ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stepId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.stepId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stepStatusId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.stepStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stepDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.stepDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stepTime", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.stepTime ?? DBNull.Value);
    
                ExecuteNonQueryCommand(comm, "spUpdateOfficeSetupSteps", ct.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsOfficeSetupSteps> SelectAllOfficeSetupSteps(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeSetupSteps");

                List<clsOfficeSetupSteps> contactList = new List<clsOfficeSetupSteps>();
                TExecuteReaderCmd<clsOfficeSetupSteps>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeSetupSteps>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeSetupSteps>();
        }
        public List<clsOfficeSetupSteps> SelectOfficeSetupStepsById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeSetupStepsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeSetupSteps> contactList = new List<clsOfficeSetupSteps>();
                TExecuteReaderCmd<clsOfficeSetupSteps>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeSetupSteps>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeSetupSteps>();
        }
        public List<clsOfficeSetupSteps> SelectOfficeSetupStepsByOfficeId(int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeSetupStepsByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsOfficeSetupSteps> contactList = new List<clsOfficeSetupSteps>();
                TExecuteReaderCmd<clsOfficeSetupSteps>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeSetupSteps>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeSetupSteps>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeSetupSteps> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeSetupSteps obj = new clsOfficeSetupSteps();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.stepId = returnData["stepId"] is DBNull ? (int)0 : (int)returnData["stepId"];
                    obj.stepStatusId = returnData["stepStatusId"] is DBNull ? (int)0 : (int)returnData["stepStatusId"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                    obj.stepDate = returnData["stepDate"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["stepDate"];
                    obj.stepTime = returnData["stepTime"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["stepTime"];
                    if (ColumnExists(returnData, "stepName"))
                    {
                        obj.stepName = returnData["stepName"] is DBNull ? (string) string.Empty : (string)returnData["stepName"];
                    }
                    if (ColumnExists(returnData, "stepStatusName"))
                    {
                        obj.stepStatusName = returnData["stepStatusName"] is DBNull ? (string)string.Empty : (string)returnData["stepStatusName"];
                    }
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
