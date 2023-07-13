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
   public class accrIndustrialCodeCategoryMapDAL : SQLDataAccess
    {
        public int InsertAccrIndustrialCodeCategoryMap(clsAccrIndustrialCodeCategoryMap obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrIndustrialCodeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accrIndustrialCodeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrIndustrialCodeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accrIndustrialCodeTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subCategoryCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.subCategoryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subTitleCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.subTitleCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccrIndustrialCodeCategoryMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccrIndustrialCodeCategoryMap(clsAccrIndustrialCodeCategoryMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrIndustrialCodeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accrIndustrialCodeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrIndustrialCodeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accrIndustrialCodeTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subCategoryCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.subCategoryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subTitleCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.subTitleCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccrIndustrialCodeCategoryMap", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAccrIndustrialCodeCategoryMap> SelectAllAccrIndustrialCodeCategoryMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccrIndustrialCodeCategoryMap");

                List<clsAccrIndustrialCodeCategoryMap> activeList = new List<clsAccrIndustrialCodeCategoryMap>();
                TExecuteReaderCmd<clsAccrIndustrialCodeCategoryMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrIndustrialCodeCategoryMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrIndustrialCodeCategoryMap>();
        }
        public List<clsAccrIndustrialCodeCategoryMap> SelectAccrIndustrialCodeCategoryMapById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrIndustrialCodeCategoryMapById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccrIndustrialCodeCategoryMap> activeList = new List<clsAccrIndustrialCodeCategoryMap>();
                TExecuteReaderCmd<clsAccrIndustrialCodeCategoryMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrIndustrialCodeCategoryMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrIndustrialCodeCategoryMap>();
        }   
        public List<clsAccrIndustrialCodeCategoryMap> SelectAllAccrIndustrialCodeCategoryMapByAccreditationBodyStandardIdAndAccrIndustrialCodeId(int accreditationBodyStandardId,int accrIndustrialCodeTypeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccrIndustrialCodeCategoryMapByAccreditationBodyStandardIdAndAccrIndustrialCodeId");
                comand.Parameters.AddWithValue("@accreditationBodyStandardId", accreditationBodyStandardId);
                comand.Parameters.AddWithValue("@accrIndustrialCodeTypeId", accrIndustrialCodeTypeId);
                List<clsAccrIndustrialCodeCategoryMap> activeList = new List<clsAccrIndustrialCodeCategoryMap>();
                TExecuteReaderCmd<clsAccrIndustrialCodeCategoryMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrIndustrialCodeCategoryMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrIndustrialCodeCategoryMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccrIndustrialCodeCategoryMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccrIndustrialCodeCategoryMap obj = new clsAccrIndustrialCodeCategoryMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accrIndustrialCodeId = returnData["accrIndustrialCodeId"] is DBNull ? (int)0 : (int)returnData["accrIndustrialCodeId"];
                    obj.accreditationBodyStandardId = returnData["accreditationBodyStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationBodyStandardId"];
                    obj.accrIndustrialCodeTypeId = returnData["accrIndustrialCodeTypeId"] is DBNull ? (int)0 : (int)returnData["accrIndustrialCodeTypeId"];
                    obj.subCategoryCode= returnData["subCategoryCode"] is DBNull ? (string)string.Empty : (string)returnData["subCategoryCode"];
                    obj.subTitleCode= returnData["subTitleCode"] is DBNull ? (string)string.Empty : (string)returnData["subTitleCode"];
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
        public bool ActiveFalseForDeleteAccrIndustrialCodeCategoryMapById(int id, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spActiveFalseForDeleteAccrIndustrialCodeCategoryMapById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
