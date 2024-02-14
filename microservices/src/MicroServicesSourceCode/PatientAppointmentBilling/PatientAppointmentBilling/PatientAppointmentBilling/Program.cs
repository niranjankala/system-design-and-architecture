using AppCQRSModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using MediatR;
using System.Reflection;
using AppBillModel;
using System.Threading;

namespace PatientAppointmentBilling
{
    class Program
    {
        static void Main(string[] args)
        {
            // register all my depencides

            Patient p = new Patient();
            p.Name = "";
            p.AddHistory("Diab");
            p.AddHistory("Sug");

            var serviceProvider = CreateService();
            var cmdcreate = new CreatePatient();
            cmdcreate.Name = "Shiv";
            var handler = serviceProvider.GetService<IRequestHandler<CreatePatient>>();
            var handler2 = serviceProvider.GetService<IRequestHandler<UpdatePatient>>();
            CancellationToken tk;
            handler.Handle(cmdcreate,tk);
            Console.Read();

        }
        public static ServiceProvider CreateService()
        {
            var services = new ServiceCollection();
            services.AddMediatR(cfg => cfg.
                        RegisterServicesFromAssembly(
                        typeof(CreatePatientHandler).GetTypeInfo().Assembly));
            //services.AddTransient<IHandler<CreatePatient>, CreatePatientHandler>();
            //services.AddTransient<IHandler<UpdatePatient>, UpdatePatientHandler>();

            return services.BuildServiceProvider();
        }
    }
}
