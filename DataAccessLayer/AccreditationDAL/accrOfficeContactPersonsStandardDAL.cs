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
   public class accrOfficeContactPersonsStandardDAL : SQLDataAccess
    {
        public int InsertAccrOfficeContactPersonsStandard(clsAccrOfficeContactPersonsStandard obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrOfficeContactPersonsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accrOfficeContactPersonsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccrOfficeContactPersonsStandard", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccrOfficeContactPersonsStandard(clsAccrOfficeContactPersonsStandard obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrOfficeContactPersonsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accrOfficeContactPersonsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccrOfficeContactPersonsStandard", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccrOfficeContactPersonsStandard> SelectAllAccrOfficeContactPersonsStandard(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccrOfficeContactPersonsStandard");

                List<clsAccrOfficeContactPersonsStandard> activeList = new List<clsAccrOfficeContactPersonsStandard>();
                TExecuteReaderCmd<clsAccrOfficeContactPersonsStandard>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrOfficeContactPersonsStandard>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrOfficeContactPersonsStandard>();
        }
        public List<clsAccrOfficeContactPersonsStandard> SelectAccrOfficeContactPersonsStandardById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrOfficeContactPersonsStandardById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccrOfficeContactPersonsStandard> activeList = new List<clsAccrOfficeContactPersonsStandard>();
                TExecuteReaderCmd<clsAccrOfficeContactPersonsStandard>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrOfficeContactPersonsStandard>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrOfficeContactPersonsStandard>();
        }
        public List<clsAccrOfficeContactPersonsStandard> SelectAccrOfficeContactPersonsStandardByAccrOfficeContactPersonsId(int accrOfficeContactPersonsId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrOfficeContactPersonsStandardByAccrOfficeContactPersonsId");
                comand.Parameters.AddWithValue("@accrOfficeContactPersonsId", accrOfficeContactPersonsId);
                List<clsAccrOfficeContactPersonsStandard> activeList = new List<clsAccrOfficeContactPersonsStandard>();
                TExecuteReaderCmd<clsAccrOfficeContactPersonsStandard>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrOfficeContactPersonsStandard>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrOfficeContactPersonsStandard>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccrOfficeContactPersonsStandard> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccrOfficeContactPersonsStandard obj = new clsAccrOfficeContactPersonsStandard();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.accrOfficeContactPersonsId = returnData["accrOfficeContactPersonsId"] is DBNull ? (int)0 : (int)returnData["accrOfficeContactPersonsId"];
                    obj.standardName= returnData["standardName"] is DBNull ? (string)string.Empty : (string)returnData["standardName"];
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
        public bool DeleteAccrChargesCountryMapByAccrOfficeContactPersonsId(int accrOfficeContactPersonsId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@accrOfficeContactPersonsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)accrOfficeContactPersonsId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteAccrChargesCountryMapByAccrOfficeContactPersonsId", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
