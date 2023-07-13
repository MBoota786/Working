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
   public class officeTaxDetailDAL : SQLDataAccess
    {
        public int InsertOfficeTaxDetail(clsOfficeTaxDetail obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTaxId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeTaxId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.taxName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.taxTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxCountryCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.taxCountryCategoryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@costTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.costTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxRate", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.taxRate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@seviceFeeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceFeeTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxTermId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.taxTermId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isTaxStateOther", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isTaxStateOther ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeTaxDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeTaxDetail(clsOfficeTaxDetail obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTaxId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeTaxId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.taxName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.taxTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxCountryCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.taxCountryCategoryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@costTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.costTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxRate", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.taxRate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@seviceFeeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceFeeTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxTermId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.taxTermId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isTaxStateOther", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isTaxStateOther ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeTaxDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeTaxDetail> SelectAllOfficeTaxDetail(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeTaxDetail");
                SetDBName(dbName);
                List<clsOfficeTaxDetail> activeList = new List<clsOfficeTaxDetail>();
                TExecuteReaderCmd<clsOfficeTaxDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeTaxDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeTaxDetail>();
        }
        public List<clsOfficeTaxDetail> SelectOfficeTaxDetailById(int id, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeTaxDetailById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeTaxDetail> activeList = new List<clsOfficeTaxDetail>();
                TExecuteReaderCmd<clsOfficeTaxDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeTaxDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeTaxDetail>();
        } 
        public List<clsOfficeTaxDetail> SelectOfficeTaxDetailByOfficeTaxId(int officeTaxId, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeTaxDetailByOfficeTaxId");
                comand.Parameters.AddWithValue("@officeTaxId", officeTaxId);
                List<clsOfficeTaxDetail> activeList = new List<clsOfficeTaxDetail>();
                TExecuteReaderCmd<clsOfficeTaxDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeTaxDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeTaxDetail>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeTaxDetail> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeTaxDetail obj = new clsOfficeTaxDetail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeTaxId = returnData["officeTaxId"] is DBNull ? (int)0 : (int)returnData["officeTaxId"];
                    obj.taxName = returnData["taxName"] is DBNull ? (string) string.Empty : (string)returnData["taxName"];
                    obj.taxTypeId = returnData["taxTypeId"] is DBNull ? (int)0 : (int)returnData["taxTypeId"];
                    obj.taxCountryCategoryId = returnData["taxCountryCategoryId"] is DBNull ? (int)0 : (int)returnData["taxCountryCategoryId"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.costTypeId = returnData["costTypeId"] is DBNull ? (int)0 : (int)returnData["costTypeId"];
                    obj.taxRate = returnData["taxRate"] is DBNull ? (decimal)0 : (decimal)returnData["taxRate"];
                    obj.isTaxStateOther = returnData["isTaxStateOther"] is DBNull ? (bool)true : (bool)returnData["isTaxStateOther"];
                    obj.serviceFeeTypeId = returnData["seviceFeeTypeId"] is DBNull ? (int)0 : (int)returnData["seviceFeeTypeId"];
                    obj.taxTermId = returnData["taxTermId"] is DBNull ? (int)0 : (int)returnData["taxTermId"];
                    obj.taxTermName = ColumnExists(returnData, "taxTermName") ? returnData["taxTermName"] is DBNull ? (string) string.Empty : (string)returnData["taxTermName"] : string.Empty;
                    obj.taxType = ColumnExists(returnData, "taxType") ? returnData["taxType"] is DBNull ? (string) string.Empty : (string)returnData["taxType"] : string.Empty;
                    obj.serviceFeeTypeName = ColumnExists(returnData, "serviceFeeTypeName") ? returnData["serviceFeeTypeName"] is DBNull ? (string) string.Empty : (string)returnData["serviceFeeTypeName"] : string.Empty;
                    obj.countryName = ColumnExists(returnData, "countryName") ? returnData["countryName"] is DBNull ? (string) string.Empty : (string)returnData["countryName"] : string.Empty;
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
