using Domain.Customers;
namespace Infra;
using Microsoft.EntityFrameworkCore;


public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    
    public DbSet<Customer> Customer { get; set; }
}