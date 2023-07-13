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
   public class applicationDetailDAL : SQLDataAccess
    {
        public int InsertApplicationDetail(clsApplicationDetail obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriodUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.timePeriodUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTimePeriod", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTimePeriod ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalSiteEmployees", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalSiteEmployees ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditAnnouncementTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditAnnouncementTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@regulatoryAuthority", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.regulatoryAuthority ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@certificationExpiresOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.certificationExpiresOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appSerialNo", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.appSerialNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertApplicationDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateApplicationDetail(clsApplicationDetail obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriodUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.timePeriodUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTimePeriod", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTimePeriod ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalSiteEmployees", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalSiteEmployees ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditAnnouncementTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditAnnouncementTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@regulatoryAuthority", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.regulatoryAuthority ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@certificationExpiresOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.certificationExpiresOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appSerialNo", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.appSerialNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateApplicationDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        } 
        public bool UpdateApplicationDetailAuditDurationById(clsApplicationDetail obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTimePeriod", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTimePeriod ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalSiteEmployees", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.totalSiteEmployees ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateApplicationDetailAuditDurationById", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        } 
        public bool ApplicationDetailDynamicColumnUpdateById(int id,string columnName,string columnValue,string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@columnName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)columnName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@columnValue", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)columnValue ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spApplicationDetailDynamicColumnUpdateById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsApplicationDetail> SelectAllApplicationDetail(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllApplicationDetail");

                List<clsApplicationDetail> activeList = new List<clsApplicationDetail>();
                TExecuteReaderCmd<clsApplicationDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationDetail>();
        }
        public List<clsApplicationDetail> SelectApplicationDetailById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationDetailById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsApplicationDetail> activeList = new List<clsApplicationDetail>();
                TExecuteReaderCmd<clsApplicationDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationDetail>();
        }  
        public List<clsApplicationDetail> SelectApplicationDetailByAppIdAndClientSiteId(int appId , int clientSiteId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationDetailByAppIdAndClientSiteId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsApplicationDetail> activeList = new List<clsApplicationDetail>();
                TExecuteReaderCmd<clsApplicationDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationDetail>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsApplicationDetail> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsApplicationDetail obj = new clsApplicationDetail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.auditAnnouncementTypeId = returnData["auditAnnouncementTypeId"] is DBNull ? (int)0 : (int)returnData["auditAnnouncementTypeId"];
                    obj.timePeriodUnitId = returnData["timePeriodUnitId"] is DBNull ? (int)0 : (int)returnData["timePeriodUnitId"];
                    obj.auditTimePeriod = returnData["auditTimePeriod"] is DBNull ? (int)0 : (int)returnData["auditTimePeriod"];
                    obj.totalSiteEmployees = returnData["totalSiteEmployees"] is DBNull ? (int)0 : (int)returnData["totalSiteEmployees"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.regulatoryAuthority = returnData["regulatoryAuthority"] is DBNull ? (string)string.Empty : (string)returnData["regulatoryAuthority"];
                    obj.certificationExpiresOn = returnData["certificationExpiresOn"] is DBNull ? (DateTime?)null : (DateTime)returnData["certificationExpiresOn"];
                    obj.appSerialNo = returnData["appSerialNo"] is DBNull ? (string)string.Empty : (string)returnData["appSerialNo"];
                    obj.timePeriodUnit = returnData["timePeriodUnit"] is DBNull ? (string)string.Empty : (string)returnData["timePeriodUnit"];
                    obj.standardName = returnData["standardName"] is DBNull ? (string)string.Empty : (string)returnData["standardName"];
                    
                    obj.siteCertificationScope = ColumnExists(returnData, "siteCertificationScope") ? returnData["siteCertificationScope"] is DBNull ? (string)string.Empty : (string)returnData["siteCertificationScope"] :string.Empty;
                    obj.isSiteEngagedWithConsultant = ColumnExists(returnData, "isSiteEngagedWithConsultant") ? returnData["isSiteEngagedWithConsultant"] is DBNull ? (bool)false : (bool)returnData["isSiteEngagedWithConsultant"] : false;

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
        public List<clsApplicationDetail> SelectApplicationMasterForListByOfficeId(int officeId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationMasterForList");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsApplicationDetail> activeList = new List<clsApplicationDetail>();
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            clsApplicationDetail obj = new clsApplicationDetail();
                            obj.id = reader["id"] is DBNull ? (int) 0 : (int)reader["id"];
                            obj.appId = reader["appId"] is DBNull ? (int) 0 : (int)reader["appId"];
                            obj.appSerialNo = reader["appSerialNo"] is DBNull ? (string) string.Empty : (string)reader["appSerialNo"];
                            activeList.Add(obj);
                        }

                    }

                    con.Close();


                }
                return activeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        public List<clsApplicationDetail> SelectApplicationDetailForAuditDurationByAppIdAndClientSiteId(int appId,int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationDetailForAuditDurationByAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsApplicationDetail> activeList = new List<clsApplicationDetail>();
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            clsApplicationDetail obj = new clsApplicationDetail();
                            obj.id = reader["id"] is DBNull ? (int) 0 : (int)reader["id"];
                            obj.appId = reader["appId"] is DBNull ? (int) 0 : (int)reader["appId"];
                            obj.clientSiteId = reader["clientSiteId"] is DBNull ? (int) 0 : (int)reader["clientSiteId"];
                            obj.siteName = reader["siteName"] is DBNull ? (string) string.Empty : (string)reader["siteName"];
                            obj.accreditationStandardId = reader["accreditationStandardId"] is DBNull ? (int)0 : (int)reader["accreditationStandardId"];
                            obj.standardName = reader["standardName"] is DBNull ? (string)string.Empty : (string)reader["standardName"];
                            obj.auditTypeId = reader["auditTypeId"] is DBNull ? (int)0 : (int)reader["auditTypeId"];
                            obj.auditTypeName = reader["auditTypeName"] is DBNull ? (string)string.Empty : (string)reader["auditTypeName"];
                            obj.auditAnnouncementTypeId = reader["auditAnnouncementTypeId"] is DBNull ? (int)0 : (int)reader["auditAnnouncementTypeId"];
                            obj.announcementTypeName = reader["announcementTypeName"] is DBNull ? (string)string.Empty : (string)reader["announcementTypeName"];
                            obj.totalSiteEmployees = reader["totalSiteEmployees"] is DBNull ? (int)0 : (int)reader["totalSiteEmployees"];
                            obj.timePeriodUnitId = reader["timePeriodUnitId"] is DBNull ? (int)0 : (int)reader["timePeriodUnitId"];
                            obj.auditTimePeriod = reader["auditTimePeriod"] is DBNull ? (int)0 : (int)reader["auditTimePeriod"];
                            obj.active = reader["active"] is DBNull ? (bool) false: (bool)reader["active"];
                            activeList.Add(obj);
                        }

                    }

                    con.Close();


                }
                return activeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
