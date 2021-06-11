using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.AspNetCore.Http;

namespace EmployeeManager2.Data
{
    public class ImageService
    {
        public async Task<string> UploadImageAsync(IFormFile imageToUpload)
        {
            string imageFullPath = null;
            if (imageToUpload == null)
            {
                return null;
            }
            try
            {
                CloudStorageAccount cloudStorageAccount = BlobConnectionClass.GetConnectionString();
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("images");

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(
                        new BlobContainerPermissions
                        {
                            PublicAccess = BlobContainerPublicAccessType.Blob
                        }
                        );
                }
                string imageName = Guid.NewGuid().ToString() + "-" + Path.GetExtension(imageToUpload.FileName);

                CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(imageName);
                cloudBlockBlob.Properties.ContentType = imageToUpload.ContentType;
                await cloudBlockBlob.UploadFromStreamAsync(imageToUpload.OpenReadStream());
                
                imageFullPath = cloudBlockBlob.Uri.ToString();
                imageFullPath = imageName;
            }
            catch (Exception ex)
            {

            }
            return imageFullPath;
        }

        public string BlobUrl()
        {
            CloudStorageAccount cloudStorageAccount = BlobConnectionClass.GetConnectionString();
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("images");

            return cloudBlobContainer.Uri.ToString();
        }

        public async Task<string> DeleteImageAsync(string imageToUpload)
        {            
            if (imageToUpload == null)
            {
                return null;
            }
            try
            {
                CloudStorageAccount cloudStorageAccount = BlobConnectionClass.GetConnectionString();
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("images");
                
                CloudBlob file = cloudBlobContainer.GetBlobReference(imageToUpload);

                if (await file.ExistsAsync())
                {
                    await file.DeleteAsync();
                }

            }
            catch (Exception ex)
            {

            }
            return "image Deleted";
        }

    }
}