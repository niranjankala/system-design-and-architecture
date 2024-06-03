using CQRSBasics.App.Interfaces;
using CQRSBasics.App.Models;

namespace CQRSBasics.App.Commands
{
    public class CreateCustomer:Customer, ICommand
    {
        public DateTime CreatedDate { get; set; }
    }
}
