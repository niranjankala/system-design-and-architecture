using Consul;

namespace ServiceDiscoveryTutorials.ClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (var client = new ConsulClient(consulConfig =>
            //{
            //    consulConfig.Address = new Uri("http://localhost:8500");
            //}))
            //{
            //    var services = await client.Catalog.Service("CatalogApi");
            //    foreach (var service in services.Response)
            //    {
            //        Console.WriteLine($"Service ID: {service.ServiceID}, Address: {service.ServiceAddress}, Port: {service.ServicePort}");
            //    }
            //}
            var consulClient = new ConsulClient();
            // Specify the service name to discover
            string serviceName = "CatalogApi";
            // Query Consul for healthy instances of the service
            var services = consulClient.Health.Service(serviceName, tag: null, passingOnly: true).Result.Response;
            // Iterate through the discovered services
            foreach (var service in services)
            {
                var serviceAddress = service.Service.Address;
                var servicePort = service.Service.Port;
                Console.WriteLine($"Found service at {serviceAddress}:{servicePort}");
                // You can now use the serviceAddress and servicePort to communicate with the discovered service.
            }


            Console.ReadKey();
        }
    }
}
