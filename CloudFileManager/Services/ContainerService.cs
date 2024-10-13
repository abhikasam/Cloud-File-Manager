
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
        public Task CreateContainer(string name)
        {
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(name);
            blobContainerClient.CreateIfNotExists(PublicAccessType.BlobContainer);
            return Task.CompletedTask;
        }

        public List<string> GetAllContainers()
        {
            List<string> containers = new List<string>();
            foreach (BlobContainerItem item in blobServiceClient.GetBlobContainers())
            {
                containers.Add(item.Name);
            }
            return containers;
        }
    }
}
