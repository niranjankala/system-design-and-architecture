namespace EventSourcingTutorials.App.Interfaces
{
    public interface IEventsBus
    {
        void Publish<T>(Guid guid, T @event) where T : IEvent;
        List<IEvent> GetEvents(Guid guid);
        List<IEvent> GetEvents();

    }
}
