using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.KnnProject.Services
{
    public class BlobModel
    {
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string FileMimeType { get; set; }
    }
    public class StorageService
    {
        string accessKey = ConfigurationManager.AppSettings["StorageConnectionString"];

        public async void DeleteBlobData(string fileUrl)
        {
            Uri uriObj = new Uri(fileUrl);
            string BlobName = Path.GetFileName(uriObj.LocalPath);

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            string strContainerName = "uploads";
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);

            string pathPrefix = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd") + "/";
            CloudBlobDirectory blobDirectory = cloudBlobContainer.GetDirectoryReference(pathPrefix);
            // get block blob refarence    
            CloudBlockBlob blockBlob = blobDirectory.GetBlockBlobReference(BlobName);

            // delete blob from container        
            await blockBlob.DeleteAsync();
        }

        private string GenerateFileName(string fileName)
        {
            string strFileName = string.Empty;
            string[] strName = fileName.Split('.');
            strFileName = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd") + "/" + DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." + strName[strName.Length - 1];
            return strFileName;
        }

        

        public async Task<List<string>> UploadFileToBlobAsync(List<BlobModel> models)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                string strContainerName = "uploads";
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);
                var listString = new List<string>();
                foreach (var item in models)
                {
                    string fileName = this.GenerateFileName(item.FileName);

                    if (await cloudBlobContainer.CreateIfNotExistsAsync())
                    {
                        await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                    }

                    if (fileName != null && item.FileData != null)
                    {
                        CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                        cloudBlockBlob.Properties.ContentType = item.FileMimeType;
                        await cloudBlockBlob.UploadFromByteArrayAsync(item.FileData, 0, item.FileData.Length);
                        
                        listString.Add(cloudBlockBlob.Uri.AbsoluteUri);
                    }
                }
                return listString;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
