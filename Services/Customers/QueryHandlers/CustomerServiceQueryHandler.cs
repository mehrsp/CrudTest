using Microsoft.EntityFrameworkCore;
using ReadInfra;
using ServiceContracts.Customers;
using ServiceContracts.Customers.Contracts;


namespace Services.Customers.QueryHandlers;

public class CustomerServiceQueryHandler:ICustomerService
{
    private readonly ReadDataContext _context;
    public CustomerServiceQueryHandler(ReadDataContext context)
    {
        _context = context;
    }
    public  List<CustomerViewModel> GetAll()
    {
        var res =  _context.Customer.Select(x => new CustomerViewModel
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                BankAccountNumber = x.BankAccountNumber

            }
        );
        return  res.ToList();
    }

    public  CustomerViewModel? GetById(int id)
    {
       var res =  _context.Customer.Select(x => new CustomerViewModel
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                BankAccountNumber = x.BankAccountNumber

            }
        ).SingleOrDefault(x => x.Id == id);
        return  res;
    }

    
}