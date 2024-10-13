namespace CloudFileManager.Services
{
    public interface IContainerService
    {
        List<string> GetAllContainers();
        Task CreateContainer(string name);
    }
}
