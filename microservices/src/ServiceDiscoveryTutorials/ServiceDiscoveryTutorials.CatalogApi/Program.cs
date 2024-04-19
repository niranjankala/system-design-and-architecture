
using Consul;

namespace ServiceDiscoveryTutorials.CatalogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddSingleton<IConsulClient>(p => new ConsulClient(consulConfig =>
            {
                consulConfig.Address = new Uri("http://localhost:8500");
            }));

            builder.Services.AddSingleton<IServiceDiscovery, ConsulServiceDiscovery>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            var discovery = app.Services.GetRequiredService<IServiceDiscovery>();
            var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
            var serviceName = "CatalogApi";
            var serviceId = Guid.NewGuid().ToString();
            var serviceAddress = "localhost";
            var servicePort = 5000;

            lifetime.ApplicationStarted.Register(async () =>
            {
                await discovery.RegisterServiceAsync(serviceName, serviceId, serviceAddress, servicePort);
            });

            lifetime.ApplicationStopping.Register(async () =>
            {
                await discovery.DeRegisterServiceAsync(serviceId);
            });


            app.Run();
        }
    }
}
