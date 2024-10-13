using Azure.Storage.Blobs;

namespace CloudFileManager.Services
{
    public class BlobStorageService
    {
        private readonly BlobServiceClient blobServiceClient;
        public BlobStorageService(IConfiguration configuration) 
        {
            blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("AzureStorage"));
        }
    }
}
