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
   public class accreditationChargesDAL : SQLDataAccess
    {
        public int InsertAccreditationCharges(clsAccreditationCharges obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@typeOfInvoiceChargeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.typeOfInvoiceChargeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriodUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.timePeriodUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfAudits", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfAudits ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@disbursementFrequency", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.disbursementFrequency ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isPeriodic", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isPeriodic ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isPerAudit", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isPerAudit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccreditationCharges", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccreditationCharges(clsAccreditationCharges obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@typeOfInvoiceChargeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.typeOfInvoiceChargeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriodUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.timePeriodUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfAudits", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfAudits ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@disbursementFrequency", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.disbursementFrequency ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isPeriodic", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isPeriodic ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isPerAudit", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isPerAudit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationCharges", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationCharges> SelectAllAccreditationCharges(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationCharges");

                List<clsAccreditationCharges> activeList = new List<clsAccreditationCharges>();
                TExecuteReaderCmd<clsAccreditationCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationCharges>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationCharges>();
        }
        public List<clsAccreditationCharges> SelectAccreditationChargesById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationChargesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationCharges> activeList = new List<clsAccreditationCharges>();
                TExecuteReaderCmd<clsAccreditationCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationCharges>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationCharges>();
        }
        public List<clsAccreditationCharges> SelectAccreditationChargesByAccreditationId(int accreditationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationChargesByAccreditationId");
                comand.Parameters.AddWithValue("@accreditationId", accreditationId);
                List<clsAccreditationCharges> activeList = new List<clsAccreditationCharges>();
                TExecuteReaderCmd<clsAccreditationCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationCharges>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationCharges>();
        } 
        public List<clsAccreditationCharges> SelectAccreditationChargesByAccreditationIdAndAccreditationStandardId(int accreditationId,int accreditationStandardId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationChargesByAccreditationIdAndAccreditationStandardId");
                comand.Parameters.AddWithValue("@accreditationId", accreditationId);
                comand.Parameters.AddWithValue("@accreditationStandardId", accreditationStandardId);
                List<clsAccreditationCharges> activeList = new List<clsAccreditationCharges>();
                TExecuteReaderCmd<clsAccreditationCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationCharges>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationCharges>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationCharges> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationCharges obj = new clsAccreditationCharges();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationId = returnData["accreditationId"] is DBNull ? (int)0 : (int)returnData["accreditationId"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.typeOfInvoiceChargeId = returnData["typeOfInvoiceChargeId"] is DBNull ? (int)0 : (int)returnData["typeOfInvoiceChargeId"];
                    obj.timePeriodUnitId = returnData["timePeriodUnitId"] is DBNull ? (int) 0 : (int)returnData["timePeriodUnitId"];
                    obj.noOfAudits = returnData["noOfAudits"] is DBNull ? (int)0 : (int)returnData["noOfAudits"];
                    obj.currencyId = returnData["currencyId"] is DBNull ? (int)0 : (int)returnData["currencyId"];
                    obj.disbursementFrequency = returnData["disbursementFrequency"] is DBNull ? (int)0 : (int)returnData["disbursementFrequency"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    if (ColumnExists(returnData, "isPeriodic"))
                    {
                        obj.isPeriodic = returnData["isPeriodic"] is DBNull ? (bool)true : (bool)returnData["isPeriodic"];
                    }
                    if (ColumnExists(returnData, "isPerAudit"))
                    {
                        obj.isPerAudit = returnData["isPerAudit"] is DBNull ? (bool)true : (bool)returnData["isPerAudit"];
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
