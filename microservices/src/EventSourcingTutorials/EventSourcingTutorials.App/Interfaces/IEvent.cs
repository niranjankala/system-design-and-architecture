using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingTutorials.App.Interfaces
{
    public interface IEvent
    {
        public string Guid { get; set; }
    }    
}
