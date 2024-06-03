using CQRSBasics.App.Commands;
using CQRSBasics.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSBasics.App.Handlers
{
    internal class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        public void Handle(CreateCustomer command)
        {
            Console.WriteLine($"{command.Name} inserted in to DB using EF");
            //Event Queue
        }
    }
}
