using Consul;

namespace ServiceDiscoveryTutorials.CatalogApi
{
    public interface IServiceDiscovery
    {
        Task RegisterServiceAsync(string serviceName, string serviceId, string serviceAddress, int servicePort);
        Task RegisterServiceAsync(AgentServiceRegistration serviceRegistration);
        
        Task DeRegisterServiceAsync(string serviceId);
    }
}