using EventSourcingTutorials.App.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingTutorials.App.Events
{
    public class EventsBus : IEventsBus
    {
        IEventStore eventsrc = new EventStore();
        public void Publish<T>(Guid g, T @event) where T : IEvent
        {
            var handler = Program.kernel.Get<IEventHandler<T>>();
            handler.Handle(@event); // publish to extern Rabbit MQ
            this.eventsrc.SaveEvents(g, @event); // internally store
        }
        public List<IEvent> GetEvents(Guid aggregateId)
        {
            return eventsrc.GetEvents(aggregateId);
        }

        public List<IEvent> GetEvents()
        {
            return eventsrc.GetEvents();
        }
    }
}
