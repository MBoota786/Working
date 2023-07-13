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
   public class standardFixQuestionsDAL : SQLDataAccess
    {
        public int InsertStandardFixQuestions(clsStandardFixQuestions obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWrapFirstTimeAudit", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWrapFirstTimeAudit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWrapReCertification", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWrapReCertification ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isLapsedAudit", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isLapsedAudit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapFacilityId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.wrapFacilityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapLastAuditDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.wrapLastAuditDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapCertificateExpiryDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.wrapCertificateExpiryDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWrapPcaConductedFacility", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWrapPcaConductedFacility ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapPcaDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.wrapPcaDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWrapOpenPcaFinded", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWrapOpenPcaFinded ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapWhoConductPca", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.wrapWhoConductPca ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapExpectedAuditDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.wrapExpectedAuditDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSmetaFullInitial", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaFullInitial ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSmetaPeriodic", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaPeriodic ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSmetaFullFollowup", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaFullFollowup ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSmetaPartialFollowup", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaPartialFollowup ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSmetaRegisterSedex", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaRegisterSedex ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@smetaSedexRegNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.smetaSedexRegNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@smetaSedexRegId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.smetaSedexRegId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@smetaExpectedAuditDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.smetaExpectedAuditDate ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@isCtpatFullInitial", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isCtpatFullInitial ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@ctpatExpectedAuditDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.ctpatExpectedAuditDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@announcementTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.announcementTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditWindowInWeek", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditWindowInWeek ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertStandardFixQuestions", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStandardFixQuestions(clsStandardFixQuestions obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWrapFirstTimeAudit", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWrapFirstTimeAudit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWrapReCertification", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWrapReCertification ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isLapsedAudit", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isLapsedAudit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapFacilityId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.wrapFacilityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapLastAuditDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.wrapLastAuditDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapCertificateExpiryDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.wrapCertificateExpiryDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWrapPcaConductedFacility", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWrapPcaConductedFacility ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapPcaDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.wrapPcaDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWrapOpenPcaFinded", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWrapOpenPcaFinded ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapWhoConductPca", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.wrapWhoConductPca ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapExpectedAuditDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.wrapExpectedAuditDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSmetaFullInitial", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaFullInitial ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSmetaPeriodic", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaPeriodic ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSmetaFullFollowup", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaFullFollowup ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSmetaPartialFollowup", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaPartialFollowup ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSmetaRegisterSedex", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaRegisterSedex ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@smetaSedexRegNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.smetaSedexRegNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@smetaSedexRegId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.smetaSedexRegId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@smetaExpectedAuditDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.smetaExpectedAuditDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isCtpatFullInitial", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isCtpatFullInitial ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@ctpatExpectedAuditDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.ctpatExpectedAuditDate ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@announcementTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.announcementTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditWindowInWeek", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditWindowInWeek ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateStandardFixQuestions", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }  
        public bool UpdateStandardFixQuestionsForReview(clsStandardFixQuestions obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@isWrapFirstTimeAudit", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWrapFirstTimeAudit ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@isWrapReCertification", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWrapReCertification ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@isLapsedAudit", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isLapsedAudit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapFacilityId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.wrapFacilityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapLastAuditDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.wrapLastAuditDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapCertificateExpiryDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.wrapCertificateExpiryDate ?? DBNull.Value);
              //  AddParamToSQLCmd(comm, "@isWrapPcaConductedFacility", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWrapPcaConductedFacility ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapPcaDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.wrapPcaDate ?? DBNull.Value);
              //  AddParamToSQLCmd(comm, "@isWrapOpenPcaFinded", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWrapOpenPcaFinded ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapWhoConductPca", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.wrapWhoConductPca ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@wrapExpectedAuditDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.wrapExpectedAuditDate ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@isSmetaFullInitial", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaFullInitial ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@isSmetaPeriodic", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaPeriodic ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@isSmetaFullFollowup", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaFullFollowup ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@isSmetaPartialFollowup", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaPartialFollowup ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@isSmetaRegisterSedex", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSmetaRegisterSedex ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@smetaSedexRegNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.smetaSedexRegNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@smetaSedexRegId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.smetaSedexRegId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@smetaExpectedAuditDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.smetaExpectedAuditDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@ctpatExpectedAuditDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.ctpatExpectedAuditDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                //AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateStandardFixQuestionsForReview", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsStandardFixQuestions> SelectAllStandardFixQuestions(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardFixQuestions");

                List<clsStandardFixQuestions> adressList = new List<clsStandardFixQuestions>();
                TExecuteReaderCmd<clsStandardFixQuestions>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardFixQuestions>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardFixQuestions>();
        }
        public List<clsStandardFixQuestions> SelectStandardFixQuestionsById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardFixQuestionsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsStandardFixQuestions> adressList = new List<clsStandardFixQuestions>();
                TExecuteReaderCmd<clsStandardFixQuestions>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardFixQuestions>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardFixQuestions>();
        }
        public List<clsStandardFixQuestions> SelectStandardFixQuestionsByAppIdAndClientSiteIdAndAccreditationBodyStandardId(int appId,int clientSiteId,int accreditationBodyStandardId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardFixQuestionsByAppIdAndClientSiteIdAndAccreditationBodyStandardId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                comand.Parameters.AddWithValue("@accreditationBodyStandardId", accreditationBodyStandardId);
                List<clsStandardFixQuestions> adressList = new List<clsStandardFixQuestions>();
                TExecuteReaderCmd<clsStandardFixQuestions>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardFixQuestions>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardFixQuestions>();
        } 
        public List<clsStandardFixQuestions> SelectStandardFixQuestionsByAppIdAndClientSiteId(int appId,int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardFixQuestionsByAppIdAndClientSiteId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsStandardFixQuestions> adressList = new List<clsStandardFixQuestions>();
                TExecuteReaderCmd<clsStandardFixQuestions>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardFixQuestions>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardFixQuestions>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardFixQuestions> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardFixQuestions obj = new clsStandardFixQuestions();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.accreditationBodyStandardId = returnData["accreditationBodyStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationBodyStandardId"];
                    obj.isWrapFirstTimeAudit = returnData["isWrapFirstTimeAudit"] is DBNull ? (bool)false : (bool)returnData["isWrapFirstTimeAudit"];
                    obj.isWrapReCertification = returnData["isWrapReCertification"] is DBNull ? (bool)false : (bool)returnData["isWrapReCertification"];
                    obj.isLapsedAudit = returnData["isLapsedAudit"] is DBNull ? (bool)false : (bool)returnData["isLapsedAudit"];
                    obj.wrapFacilityId = returnData["wrapFacilityId"] is DBNull ? (string) string.Empty : (string)returnData["wrapFacilityId"];
                    obj.wrapLastAuditDate = returnData["wrapLastAuditDate"] is DBNull ? (DateTime?) null : (DateTime)returnData["wrapLastAuditDate"];
                    obj.wrapCertificateExpiryDate = returnData["wrapCertificateExpiryDate"] is DBNull ? (DateTime?) null : (DateTime)returnData["wrapCertificateExpiryDate"];
                    obj.isWrapPcaConductedFacility = returnData["isWrapPcaConductedFacility"] is DBNull ? (bool)false : (bool)returnData["isWrapPcaConductedFacility"];
                    obj.wrapPcaDate = returnData["wrapPcaDate"] is DBNull ? (DateTime?)null: (DateTime)returnData["wrapPcaDate"];
                    obj.isWrapOpenPcaFinded = returnData["isWrapOpenPcaFinded"] is DBNull ? (bool)false : (bool)returnData["isWrapOpenPcaFinded"];
                    obj.wrapWhoConductPca = returnData["wrapWhoConductPca"] is DBNull ? (string) string.Empty : (string)returnData["wrapWhoConductPca"];
                    obj.wrapExpectedAuditDate = returnData["wrapExpectedAuditDate"] is DBNull ? (DateTime?) null : (DateTime)returnData["wrapExpectedAuditDate"];
                    obj.isSmetaFullInitial = returnData["isSmetaFullInitial"] is DBNull ? (bool)false : (bool)returnData["isSmetaFullInitial"];
                    obj.isSmetaPeriodic = returnData["isSmetaPeriodic"] is DBNull ? (bool)false : (bool)returnData["isSmetaPeriodic"];
                    obj.isSmetaFullFollowup = returnData["isSmetaFullFollowup"] is DBNull ? (bool)false : (bool)returnData["isSmetaFullFollowup"];
                    obj.isSmetaPartialFollowup = returnData["isSmetaPartialFollowup"] is DBNull ? (bool)false : (bool)returnData["isSmetaPartialFollowup"];
                    obj.isSmetaRegisterSedex = returnData["isSmetaRegisterSedex"] is DBNull ? (bool)false : (bool)returnData["isSmetaRegisterSedex"];
                    obj.smetaSedexRegNumber = returnData["smetaSedexRegNumber"] is DBNull ? (string) string.Empty : (string)returnData["smetaSedexRegNumber"];
                    obj.smetaSedexRegId = returnData["smetaSedexRegId"] is DBNull ? (string) string.Empty : (string)returnData["smetaSedexRegId"];
                    obj.smetaExpectedAuditDate = returnData["smetaExpectedAuditDate"] is DBNull ? (DateTime?) null : (DateTime)returnData["smetaExpectedAuditDate"];
                    obj.ctpatExpectedAuditDate = returnData["ctpatExpectedAuditDate"] is DBNull ? (DateTime?) null : (DateTime)returnData["ctpatExpectedAuditDate"];
                    obj.isCtpatFullInitial = returnData["isCtpatFullInitial"] is DBNull ? (bool)false : (bool)returnData["isCtpatFullInitial"];
                    obj.announcementTypeId = returnData["announcementTypeId"] is DBNull ? (int) 0: (int)returnData["announcementTypeId"];
                    obj.auditWindowInWeek = returnData["auditWindowInWeek"] is DBNull ? (int) 0: (int)returnData["auditWindowInWeek"];
                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
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
