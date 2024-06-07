using EasyNetQ;
using EventSourcingTutorials.App.Interfaces;

namespace EventSourcingTutorials.App.Events.Handlers
{
    public class CustomerCreatedEventHandler : IEventHandler<CustomerCreated>
    {

        public void Handle(CustomerCreated event1)
        {
            var bus = RabbitHutch.CreateBus("host=localhost");
            bus.PubSub.Publish<CustomerCreated>(event1);
            System.Console.WriteLine($"User was created {event1.Guid} - event");
        }
    }
}
