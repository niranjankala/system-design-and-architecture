using CQRSBasics.App.Models;

namespace CQRSBasics.App.Commands
{
    public class UpdateCustomer : Customer
    {
        public string UpdateBy {  get; set; }
    }
}
