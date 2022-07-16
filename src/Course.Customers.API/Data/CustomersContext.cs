using Course.Customers.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Course.Customers.API.Data
{
    public class CustomersContext : DbContext 
    {
        public DbSet<Customer> Customer { get; set; }
        public CustomersContext(DbContextOptions<CustomersContext> Options)
            : base(Options)
        {
                
        }
    }
}
