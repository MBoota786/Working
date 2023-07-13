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
  public class accreditationBodyStandardDAL : SQLDataAccess
    {
        public int InsertAccreditationBodyStandard(clsAccreditationBodyStandard obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationIndstrCodeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationIndstrCodeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditStandardsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditStandardsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationDurationFrom", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.accreditationDurationFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationDurationTo", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.accreditationDurationTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccreditationCategory", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccreditationBodyStandard(clsAccreditationBodyStandard obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationIndstrCodeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationIndstrCodeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditStandardsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditStandardsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationDurationFrom", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.accreditationDurationFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationDurationTo", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.accreditationDurationTo ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationBodyStandard", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationBodyStandard> SelectAllAccreditationBodyStandard()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationBodyStandard");

                List<clsAccreditationBodyStandard> activeList = new List<clsAccreditationBodyStandard>();
                TExecuteReaderCmd<clsAccreditationBodyStandard>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationBodyStandard>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsAccreditationBodyStandard> SelectAccreditationBodyStandardById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationBodyStandardById");
                comand.Parameters.AddWithValue("@id", id);

                List<clsAccreditationBodyStandard> activeList = new List<clsAccreditationBodyStandard>();
                TExecuteReaderCmd<clsAccreditationBodyStandard>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationBodyStandard>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }  
        public List<clsAccreditationBodyStandard> SelectAccreditationBodyStandardByAccreditationId(int accreditationId)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationBodyStandardByAccreditationId");
                comand.Parameters.AddWithValue("@accreditationId", accreditationId);

                List<clsAccreditationBodyStandard> activeList = new List<clsAccreditationBodyStandard>();
                TExecuteReaderCmd<clsAccreditationBodyStandard>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationBodyStandard>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationBodyStandard>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationBodyStandard> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationBodyStandard obj = new clsAccreditationBodyStandard();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationId= returnData["accreditationId"] is DBNull ? (int)0 : (int)returnData["accreditationId"];
                    obj.auditStandardsId= returnData["auditStandardsId"] is DBNull ? (int)0 : (int)returnData["auditStandardsId"];
                    obj.standardName= returnData["standardName"] is DBNull ? (string)string.Empty : (string)returnData["standardName"];
                    obj.accreditationIndstrCodeId= returnData["accreditationIndstrCodeId"] is DBNull ? (int)0 : (int)returnData["accreditationIndstrCodeId"];
                    obj.accreditationDurationFrom= returnData["accreditationDurationFrom"] is DBNull ? (DateTime)DateTime.Now: (DateTime)returnData["accreditationDurationFrom"];
                    obj.accreditationDurationTo = returnData["accreditationDurationTo"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["accreditationDurationTo"];
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
