using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using System.IO;
using Azure.Storage.Files.Shares;
using Azure;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.General
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class officeDocumentUploadController : ControllerBase
    {

        private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=csb1003200214e49614;AccountKey=e1CRJPMfI5L/3f7aG1J9QcUPJVjqUr8dnPDMl+LHSUQEZ2432mCI0cJVMBrkvZA7r7iQjToD6GE/+AStOEORjQ==;EndpointSuffix=core.windows.net";
        private static string fileShareName = "evolvedocumentlibrary";
        private static string folderName = "Central Document Storage";

        // POST api/<currencyController>
        [HttpPost("PostUploadOfficeDocument")]
        public async Task<IActionResult> PostUploadOfficeDocument(clsOfficeDocumentUpload objOffDoc)
        {
            if (objOffDoc.companyId > 0 && objOffDoc.officeId > 0 && objOffDoc.documentMasterId > 0 && objOffDoc.documentDtlId > 0 && objOffDoc.fileByte != null)
            {
                //Get Company Main Folder
                companyDAL compDAL = new companyDAL();
                string companyFolder = compDAL.GetCompanyFolderPathById(objOffDoc.companyId, objOffDoc.dbName);

                //Get Office Folder
                officeDAL offDAL = new officeDAL();
                string officeFolder = offDAL.GetOfficeFolderPathById(objOffDoc.officeId, objOffDoc.dbName);

                string folderPath = companyFolder + "/" + officeFolder + "/" + objOffDoc.folderTitle;

                //Update Document Detail In Table
                UpdateOfficeDocumentDetail(objOffDoc.documentMasterId, objOffDoc.documentDtlId, objOffDoc.documentTitleWithExtension, folderPath, objOffDoc.dbName);
                //End
                //Upload On Azure
                UploadDocument(objOffDoc.documentTitleWithExtension, folderPath, objOffDoc.fileByte);
                //End
                return Ok("Ok");

                //Testing Code
                //   fileByte = FileToByteArray(@"C:\Users\STARIZ.PK\Downloads\download.png");
                //End
            }
            else
            {
                return BadRequest("Data Is InComplete");
            }
        }

        private void UploadDocument(string fileNameWithExtension, string path, byte[] fileByte)
        {

            //  var localFilePath = @"E:\Evolve Document\Accr Process.txt";

            Stream stream = new MemoryStream(fileByte);

            //  var fileStream = new FileStream(localFilePath, FileMode.Open, FileAccess.Read);
            //string extension = Path.GetExtension(stream.Name);
            ShareDirectoryClient shareDirectory = CreateNestedFolder(path);
            PutFileInFolder(stream, fileNameWithExtension, shareDirectory);
        }
        private static void PutFileInFolder(Stream fileStrm, string fileName, ShareDirectoryClient directoryClient)
        {
            ShareClient share = new ShareClient(connectionString, fileShareName);
            var fileDir = directoryClient.GetFileClient(fileName);


            fileDir.Create(fileStrm.Length);

            fileDir.UploadRange(
                new HttpRange(0, fileStrm.Length),
               fileStrm);
        }
        private ShareDirectoryClient CreateNestedFolder(string path)
        {
            ShareClient share = new ShareClient(connectionString, fileShareName);
            var cloudFileDirectory = share.GetRootDirectoryClient();
            var delimiter = new char[] { '/' };
            var nestedFolderArray = path.Split(delimiter);
            cloudFileDirectory = GetAndCreateMainFolder(nestedFolderArray[0]);
            for (var i = 1; i < nestedFolderArray.Length; i++)
            {
                cloudFileDirectory = cloudFileDirectory.GetSubdirectoryClient(nestedFolderArray[i]);
                cloudFileDirectory.CreateIfNotExists();
            }
            return cloudFileDirectory;
        }
        private void UpdateOfficeDocumentDetail(int documentMasterId, int documentDtlId, string documentTitleWithExtension, string documentpath, string dbName)
        {
            try
            {
                clsOfficeDocumentDtl objDoc = new clsOfficeDocumentDtl();
                objDoc.id = documentDtlId;
                objDoc.officeDocumentMasterId = documentMasterId;
                objDoc.documentFileName = documentTitleWithExtension;
                objDoc.documentPath = documentpath;
                objDoc.dbName = dbName;

                officeDocumentDtlDAL docDAL = new officeDocumentDtlDAL();
                docDAL.UpdateDocumentPathByDocumentDtlId(objDoc);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("GetAndCreateMainFolder/{mainFolder}")]
        public ShareDirectoryClient GetAndCreateMainFolder(string mainFolder)
        {
            ShareClient share = new ShareClient(connectionString, fileShareName);
            var cloudFileDirectory = share.GetRootDirectoryClient();
            cloudFileDirectory = share.GetDirectoryClient(mainFolder);
            cloudFileDirectory.CreateIfNotExists();
            cloudFileDirectory = share.GetDirectoryClient(mainFolder);
            return cloudFileDirectory;
        }
        private  byte[] FileToByteArray(string fileName)
        {
            byte[] fileContent = null;
            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
            long byteLength = new System.IO.FileInfo(fileName).Length;
            fileContent = binaryReader.ReadBytes((Int32)byteLength);
            fs.Close();
            fs.Dispose();
            binaryReader.Close();
           
            return fileContent;
        }
    }
}
