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
   public class officeCategoryRelationDAL : SQLDataAccess
    {
        public int InsertOfficeCategoryRelation(clsOfficeCategoryRelation obj)
        {
            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceScopeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@hoCategoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.hoCategoryRelationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@relatedOfficeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.relatedOfficeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isRelatedWithCO", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isRelatedWithCO ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isRelatedWithRO", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isRelatedWithRO ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isOfficeDemographicScope", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isOfficeDemographicScope ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isOfficeExclusive", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isOfficeExclusive ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeCategoryRelation", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeCategoryRelation(clsOfficeCategoryRelation obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceScopeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@hoCategoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.hoCategoryRelationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@relatedOfficeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.relatedOfficeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isRelatedWithCO", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isRelatedWithCO ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isRelatedWithRO", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isRelatedWithRO ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isOfficeDemographicScope", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isOfficeDemographicScope ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isOfficeExclusive", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isOfficeExclusive ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeCategoryRelation", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeCategoryRelation> SelectAllOfficeCategoryRelation(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeCategoryRelation");

                List<clsOfficeCategoryRelation> activeList = new List<clsOfficeCategoryRelation>();
                TExecuteReaderCmd<clsOfficeCategoryRelation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeCategoryRelation>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeCategoryRelation>();
        }
        public List<clsOfficeCategoryRelation> SelectOfficeCategoryRelationById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeCategoryRelationById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeCategoryRelation> activeList = new List<clsOfficeCategoryRelation>();
                TExecuteReaderCmd<clsOfficeCategoryRelation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeCategoryRelation>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeCategoryRelation>();
        } 
        public List<clsOfficeCategoryRelation> SelectOfficeCategoryRelationByOfficeId(int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeCategoryRelationByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsOfficeCategoryRelation> activeList = new List<clsOfficeCategoryRelation>();
                TExecuteReaderCmd<clsOfficeCategoryRelation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeCategoryRelation>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeCategoryRelation>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeCategoryRelation> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeCategoryRelation obj = new clsOfficeCategoryRelation();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.serviceScopeId = returnData["serviceScopeId"] is DBNull ? (int)0 : (int)returnData["serviceScopeId"];
                    obj.relatedOfficeId = returnData["relatedOfficeId"] is DBNull ? (int)0 : (int)returnData["relatedOfficeId"];
                    obj.hoCategoryRelationId = returnData["hoCategoryRelationId"] is DBNull ? (int)0 : (int)returnData["hoCategoryRelationId"];
                    obj.isOfficeDemographicScope = returnData["isOfficeDemographicScope"] is DBNull ? (bool) false : (bool)returnData["isOfficeDemographicScope"];
                    obj.isRelatedWithCO = returnData["isRelatedWithCO"] is DBNull ? (bool) false : (bool)returnData["isRelatedWithCO"];
                    obj.isRelatedWithRO = returnData["isRelatedWithRO"] is DBNull ? (bool) false : (bool)returnData["isRelatedWithRO"];
                    obj.isOfficeExclusive = returnData["isOfficeExclusive"] is DBNull ? (bool) false : (bool)returnData["isOfficeExclusive"];
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
