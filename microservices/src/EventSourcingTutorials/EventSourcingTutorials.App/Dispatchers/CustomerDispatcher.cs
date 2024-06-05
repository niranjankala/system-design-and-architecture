using EventSourcingTutorials.App.Events;
using EventSourcingTutorials.App.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingTutorials.App.Dispatchers
{
    public class CustomerDispatcher : IDispatcher
    {
        private readonly Guid guid;
        public readonly IEventsBus _eventPublisher;
        public CustomerDispatcher()
        {
            guid = Guid.NewGuid();
            _eventPublisher = new EventsBus();
        }

        public void Send<T>(T Command) where T : ICommand
        {
            var handler = Program.kernel.Get<ICommandHandler<T>>();
            //Command.Guid = guid.ToString();
            handler.Handle(Command);
            //_eventPublisher.Publish(guid,new CustomerCreated(guid.ToString()));
        }
    }
}
