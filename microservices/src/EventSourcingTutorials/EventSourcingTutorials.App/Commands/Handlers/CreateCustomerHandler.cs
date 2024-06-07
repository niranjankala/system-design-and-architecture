using AutoMapper;
using EventSourcingTutorials.App.Commands;
using EventSourcingTutorials.App.Data;
using EventSourcingTutorials.App.Interfaces;
using EventSourcingTutorials.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingTutorials.App.Commands.Handlers
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        public void Handle(CreateCustomer Command)
        {
            IRepository<Customer> repo = new EfCustomerContext();
            var mapper = new Mapper(Program.mappconfig);
            Customer x = mapper.Map<Customer>(Command);
            repo.Add(x);
            Console.WriteLine(Command.name + " inserted in to DB using EF");

        }
    }
}
