using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace KatlaSport.Services.ImageManagement
{
    public class ImageService : IImageService
    {
        private readonly string _storageAccountConnectionString;

        private readonly string _blobContainerName;

        private readonly string _storageAccountPath;

        private CloudBlobClient _cloudBlobClient;

        private CloudBlobContainer _cloudBlobContainer;

        public ImageService(string storageAccountConnectionString, string blobContainerName, string storageAccountPath)
        {
            _storageAccountConnectionString = storageAccountConnectionString;
            _blobContainerName = blobContainerName;
            _storageAccountPath = storageAccountPath;
            InitStorage();
        }

        public async Task<ImageResult> AddAsync(ImageData image, string oldPath)
        {
            var nameForImage = Path.GetRandomFileName();
            var imageData = Convert.FromBase64String(image.Content);
            CloudBlockBlob blob = _cloudBlobContainer.GetBlockBlobReference($"{nameForImage}{image.Extension}");
            await DeleteBlob(oldPath);
            await blob.UploadFromByteArrayAsync(imageData, 0, imageData.Length);
            var resultPath = $"{_storageAccountPath}/{_blobContainerName}/{nameForImage}{image.Extension}";
            var result = new ImageResult { NewImagePath = resultPath };
            return result;
        }

        public async Task DeleteAsync(string imagePath)
        {
            var result = new ImageResult { NewImagePath = null };
            await DeleteBlob(imagePath);
        }

        private async Task DeleteBlob(string imagePath)
        {
            if (imagePath == null)
            {
                return;
            }

            var fileName = Path.GetFileName(imagePath);
            CloudBlockBlob blobToDelete = _cloudBlobContainer.GetBlockBlobReference(fileName);
            await blobToDelete.DeleteIfExistsAsync();
        }

        private void InitStorage()
        {
            var storageAccount = CloudStorageAccount.Parse(_storageAccountConnectionString);
            _cloudBlobClient = storageAccount.CreateCloudBlobClient();
            _cloudBlobContainer = _cloudBlobClient.GetContainerReference(_blobContainerName);
            _cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        }
    }
}
