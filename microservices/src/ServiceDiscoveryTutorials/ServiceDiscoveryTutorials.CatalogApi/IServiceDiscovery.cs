namespace ServiceDiscoveryTutorials.CatalogApi
{
    public interface IServiceDiscovery
    {
        Task RegisterServiceAsync(string serviceName, string serviceId, string serviceAddress, int servicePort);
        Task DeRegisterServiceAsync(string serviceId);
    }
}