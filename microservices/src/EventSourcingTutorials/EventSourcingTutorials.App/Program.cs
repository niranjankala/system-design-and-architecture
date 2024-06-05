using EventSourcingTutorials.App.Commands;
using EventSourcingTutorials.App.Commands.Handlers;
using EventSourcingTutorials.App.Dispatchers;
using EventSourcingTutorials.App.Events;
using EventSourcingTutorials.App.Interfaces;
using Ninject;
using Ninject.Modules;
using System;
using System.Reflection;

namespace EventSourcingTutorials.App
{
    internal class Program
    {
        static public IKernel kernel = new StandardKernel(); // ninject
        static void Main(string[] args)
        {
            //kernel.Load(Assembly.GetExecutingAssembly()); // lookups
            kernel.Load(new Binding());

            IDispatcher dispatcher = new CustomerDispatcher();

            CreateCustomer newCustomer = new CreateCustomer()
            {
                Name = "Niranjan"
            };
            dispatcher.Send<CreateCustomer>(newCustomer);

            CreateCustomer newCustomer1 = new CreateCustomer()
            {
                Name = "Dhruv"
            };
            dispatcher.Send<CreateCustomer>(newCustomer1);

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
                Bind(typeof(IEventHandler<CustomerCreated>)).
                  To(typeof(CustomerCreated));

            }
        }
    }


}
