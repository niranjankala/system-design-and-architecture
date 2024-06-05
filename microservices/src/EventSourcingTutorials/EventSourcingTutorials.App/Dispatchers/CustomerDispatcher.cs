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
        public void Send<T>(T Command) where T : ICommand
        {
            var handler = Program.kernel.Get<ICommandHandler<T>>();
            handler.Handle(Command);
        }
    }
}
