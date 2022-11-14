using ApplicationContract.Customers.Commands;
using Domain.Customers;
using Domain.Customers.Services;
using Microsoft.EntityFrameworkCore;

namespace Infra.CustomersRepository;

public class CustomerRepository:ICustomerRepository
{
    private readonly DataContext _context;

    public CustomerRepository(DataContext context)
    {
        _context = context;
    }

    //public async Task<List<Customer>> GetCustomerByName(string fname,string lname,DateTime bd)
    //{
    //    return await _context.Customer.Where(x => x.Firstname == fname && x.Lastname==lname && x.DateOfBirth==bd).ToListAsync();
    //}

    public void  CreateAsync(Customer command)
    {
         _context.Customer.Add(command);
         SaveDb(_context);
    }
    public void UpdateAsync(Customer c, UpdateCommand command,ICustomerDomainService srv)
    {
         c.Update(command.FirstName, command.LastName, command.DateOfBirth, command.PhoneNumber,
            command.Email, command.BankAccountNumber,srv,c.Id);
         SaveDb(_context);
    }


    public void DeleteAsync(Customer command)
    {

       
        _context.Customer.Remove(command);
         SaveDb(_context);

    }

    public   Customer GetById(int id)
    {
        return  _context.Customer.SingleOrDefault(x => x.Id == id);
    }

    public List<Customer> GetAllCustomers()
    {
        return  _context.Customer.ToList();

    }

  
  

    private void SaveDb(DbContext ctx)
    {
        ctx.SaveChanges();

    }

  
    public List<Customer> GetAllCustomersNotId(int id)
    {
        return _context.Customer.Where(x => x.Id != id).ToList();
    }
}