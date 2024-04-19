using Consul;

namespace ServiceDiscoveryTutorials.CatalogApi
{
    public class ConsulServiceDiscovery : IServiceDiscovery
    {
        private readonly IConsulClient _consulClient;

        public ConsulServiceDiscovery(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }

        public async Task RegisterServiceAsync(string serviceName, string serviceId, string serviceAddress, int servicePort)
        {
            var registration = new AgentServiceRegistration
            {
                ID = serviceId,
                Name = serviceName,
                Address = serviceAddress,
                Port = servicePort
            };
            await _consulClient.Agent.ServiceDeregister(serviceId);
            await _consulClient.Agent.ServiceRegister(registration);
        }

        public async Task DeRegisterServiceAsync(string serviceId)
        {
            await _consulClient.Agent.ServiceDeregister(serviceId);
        }

        public async Task RegisterServiceAsync(AgentServiceRegistration registration)
        {
            await _consulClient.Agent.ServiceDeregister(registration.ID);
            await _consulClient.Agent.ServiceRegister(registration);
        }
    }
}
