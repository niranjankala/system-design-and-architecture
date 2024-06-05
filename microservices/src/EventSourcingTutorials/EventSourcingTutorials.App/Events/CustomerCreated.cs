using EventSourcingTutorials.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingTutorials.App.Events
{
    public class CustomerCreated : IEvent
    {
        public string Guid { get; set; }
        public CustomerCreated(string _guid)
        {
            this.Guid = _guid;
        }
    }
}
