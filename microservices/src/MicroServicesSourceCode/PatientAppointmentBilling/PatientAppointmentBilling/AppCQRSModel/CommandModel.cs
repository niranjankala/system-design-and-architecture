using System;
using System.Threading;
using System.Threading.Tasks;
using AppBillingService;
using AppBillModel;
using MediatR;

namespace AppCQRSModel
{
    public interface IEvent
    {

    }
    public interface IQuery
    {

    }
    public interface IResult
    {

    }
    public interface ICommand : IRequest
    {
         Guid CommandId { get;  }
    }

    //public interface IHandler<TCommand> 
    //        where TCommand : ICommand
    //{
    //    bool Handle(TCommand t);
    //}
    public abstract class BaseCommand : ICommand
    {
        public BaseCommand()
        {
            this.CommandId = Guid.NewGuid();
        }
        public Guid CommandId { get;  }
    }
    public class CreatePatientEvent : IEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string DoctorName { get; set; }
        public string Address { get; set; }
        public double BillAmount { get; set; }

        public DateTime CreatedDatetime { get; set; }
    }
    public class CreatePatient : BaseCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string DoctorName { get; set; }
        public string Address { get; set; }
        public double BillAmount { get; set; }

        public DateTime CreatedDatetime { get; set; }
    }

    public class CreatePatientHandler : IRequestHandler<CreatePatient>
    {
        public Task Handle(CreatePatient request, CancellationToken cancellationToken)
        {
            // Property by Property to the other object
            //Patient obj = new Patient();
            //obj.Name = request.Name;
            //obj.DoctorName = request.DoctorName;

            //PatientRepository r = new PatientRepository();
            //r.Save(obj); // repositry
            // Events.Adds(createObj)
            // if (Queue.Ready) Retry
            // ClinicalMS.Queue(t);
            // Audit(t)
            return null;
        }
    }
    public class UpdatePatient : BaseCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string DoctorName { get; set; }
        public string Address { get; set; }

        public DateTime UpdatedDateTime { get; set; }

    }
    public class UpdatePatientHandler : IRequestHandler<UpdatePatient>
    {
        public Task Handle(UpdatePatient request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class DeletePatient : BaseCommand
    {
        public int Id { get; set; }
       

    }
    public class QueryPatient
    {
    }
}
