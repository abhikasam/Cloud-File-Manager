namespace CloudFileManager.Services
{
    public interface IContainerService
    {
        Task<List<string>> GetAllContainers();
        Task CreateContainer(string name);

        Task DeleteContainer(string name);

    }
}
