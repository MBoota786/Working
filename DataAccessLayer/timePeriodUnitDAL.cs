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
   public class timePeriodUnitDAL : SQLDataAccess
    {
        public int InsertTimePeriodUnit(clsTimePeriodUnit obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriodUnit", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.timePeriodUnit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
              Id=  ExecuteInsertCommandReturnId(comm, "spInsertTimePeriodUnit", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateTimePeriodUnit(clsTimePeriodUnit obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriodUnit", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.timePeriodUnit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateTimePeriodUnit", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsTimePeriodUnit> SelectAllTimePeriodUnit(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllTimePeriodUnit");
                SetDBName(dbName);
                List<clsTimePeriodUnit> adressList = new List<clsTimePeriodUnit>();
                TExecuteReaderCmd<clsTimePeriodUnit>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsTimePeriodUnit>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsTimePeriodUnit> SelectTimePeriodUnitById(int id, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectTimePeriodUnitById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsTimePeriodUnit> adressList = new List<clsTimePeriodUnit>();
                TExecuteReaderCmd<clsTimePeriodUnit>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsTimePeriodUnit>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsTimePeriodUnit> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsTimePeriodUnit obj = new clsTimePeriodUnit();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.timePeriodUnit = returnData["timePeriodUnit"] is DBNull ? (string)string.Empty : (string)returnData["timePeriodUnit"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
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
