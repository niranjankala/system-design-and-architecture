using EventSourcingTutorials.App.Interfaces;

namespace EventSourcingTutorials.App.Events
{
    public class EventStore : IEventStore
    {
        private readonly Dictionary<Guid, List<IEvent>> _eventstore = new Dictionary<Guid, List<IEvent>>();

        public List<IEvent> GetEvents(Guid aggregateId)
        {
            return _eventstore[aggregateId];
        }

        public List<IEvent> GetEvents()
        {
            return _eventstore.SelectMany(d => d.Value).ToList();

        }

        public void SaveEvents(Guid aggregateId, IEvent e)
        {
            List<IEvent> events = null;
            if (!_eventstore.ContainsKey(aggregateId))
            {
                events = new List<IEvent>();
                _eventstore.Add(aggregateId, events);
            }
            else
            {
                events = _eventstore[aggregateId];
            }
            events.Add(e);
        }
    }
}
