
using ServiceContracts.Customers;

namespace ReadInfra;
using Microsoft.EntityFrameworkCore;


public class ReadDataContext : DbContext
{
    public ReadDataContext(DbContextOptions<ReadDataContext> options)
        : base(options)
    {
    }
    
    public DbSet<Customer> Customer { get; set; }
}