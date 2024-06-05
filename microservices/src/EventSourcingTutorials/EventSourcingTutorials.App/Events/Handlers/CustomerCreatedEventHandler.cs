using EventSourcingTutorials.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingTutorials.App.Events.Handlers
{
    public class CustomerCreatedEventHandler : IEventHandler<CustomerCreated>
    {

        public void Handle(CustomerCreated event1)
        {            
            System.Console.WriteLine($"User was created {event1.Guid} - event");
        }
    }
}
