using EventSourcingTutorials.App.Interfaces;
using EventSourcingTutorials.App.Models;

namespace EventSourcingTutorials.App.Commands
{
    public class CreateCustomer:Customer, ICommand
    {
        public DateTime CreatedDate { get; set; }
    }
}
