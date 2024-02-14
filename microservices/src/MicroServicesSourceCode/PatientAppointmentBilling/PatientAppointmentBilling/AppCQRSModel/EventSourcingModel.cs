using AppCQRSModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcingModel
{
    public interface IAggregateRoot
    {
         Guid Guid { get;  }
         int Version { get; }
         IEnumerable<IEvent> Events { get; }
         
    }

    public class PatientAggregate : IAggregateRoot
    {
        private Guid _Guid;
        public Guid Guid
        {
            get { return _Guid; }
        }
        private int _Version;
        public int Version
        {
            get { return _Version; }
        }
        private List<IEvent> _Events;
        public IEnumerable<IEvent> Events
        {
            get { return _Events; }
        }
        public IEvent CreatePatient(string name, int age)
        {
            var pat = new CreatePatientEvent() { Name = name, Age = age };
            PublishEvent(pat);
            return pat;
        }
        private void PublishEvent(IEvent @event){
            this._Version = this._Version + 1;
            if (@event is CreatePatientEvent)
            {
                this._Guid = Guid.NewGuid();
                this._Events.Add(@event);
                // repo.save(@event);
                
            }
        }
        
    }
}
