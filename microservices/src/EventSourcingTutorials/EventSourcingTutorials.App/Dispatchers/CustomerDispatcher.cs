using AutoMapper;
using EventSourcingTutorials.App.Events;
using EventSourcingTutorials.App.Interfaces;
using Ninject;

namespace EventSourcingTutorials.App.Dispatchers
{
    public class CustomerDispatcher : IDispatcher
    {
        public IEventsBus _eventPublisher { get; set; }

        public void Send<T>(T Command) where T : ICommand
        {
            var handler = Program.kernel.
                    Get<ICommandHandler<T>>();
            handler.Handle(Command); // calls the repository
            _eventPublisher = new EventsBus();
            Guid g = new Guid();
            string guid = g.ToString();
            var mapper = new Mapper(Program.mappconfig);
            var x1 = mapper.Map<CustomerCreated>(Command);
            _eventPublisher.Publish(g, x1); // published to external micros
        }
    }
}
