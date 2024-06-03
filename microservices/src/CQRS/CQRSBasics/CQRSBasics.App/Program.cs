using AutoMapper;
using CQRSBasics.App.Commands;
using CQRSBasics.App.Dispatchers;
using CQRSBasics.App.Handlers;
using CQRSBasics.App.Interfaces;
using Ninject;
using Ninject.Modules;
using System;
using System.Reflection;

namespace CQRSBasics.App
{
    internal class Program
    {
        static public IKernel kernel = new StandardKernel(); // ninject
        static void Main(string[] args)
        {
            kernel.Load(Assembly.GetExecutingAssembly()); // lookups


            CreateCustomer newCustomer = new CreateCustomer()
            {
                Name = "Niranjan"
            };

            IDispatcher dispatcher = new CustomerDispatcher();
            dispatcher.Send<CreateCustomer>(newCustomer);

        }

        public class Binding : NinjectModule
        {
            public override void Load()
            {
                //command
                Bind(typeof(ICommandHandler<CreateCustomer>)).
                   To(typeof(CreateCustomerHandler));
                //query

                //events

            }
        }
    }


}
