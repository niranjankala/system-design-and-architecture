using EventSourcingTutorials.App.Models;

namespace EventSourcingTutorials.App.Commands
{
    public class UpdateCustomer : Customer
    {
        public string UpdateBy {  get; set; }
    }
}
