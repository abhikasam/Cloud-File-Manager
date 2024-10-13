
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace CloudFileManager.Services
{
    public class ContainerService : IContainerService
    {
        private readonly BlobServiceClient blobServiceClient;

        public ContainerService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }
        public async Task CreateContainer(string name)
        {
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(name);
            await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);
        }

        public async Task DeleteContainer(string name)
        {
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(name);
            await blobContainerClient.DeleteIfExistsAsync();
        }

        public async Task<List<string>> GetAllContainers()
        {
            List<string> containers = new List<string>();
            await foreach (BlobContainerItem item in blobServiceClient.GetBlobContainersAsync())
            {
                containers.Add(item.Name);
            }
            return containers;
        }
    }
}
