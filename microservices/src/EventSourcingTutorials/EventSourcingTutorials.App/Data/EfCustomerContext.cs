using EventSourcingTutorials.App.Models;
using Microsoft.EntityFrameworkCore;


namespace EventSourcingTutorials.App.Data
{
    public class EfCustomerContext : EfCommon<Customer>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("tblCustomer");

        }
    }
}
