namespace EventSourcingTutorials.App.Interfaces
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEvent e);
        List<IEvent> GetEvents(Guid aggregateId);
        List<IEvent> GetEvents();
    }
}
