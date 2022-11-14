using Domain.Customers.Services;
using ReadInfra;
using ServiceContracts.Customers;

namespace Services.Customers.EventHandlers;

public class CustomerCreatedEventHandler
{
    private readonly ReadDataContext _context;

    public CustomerCreatedEventHandler(ReadDataContext context)
    {
        _context = context;
    }

    protected  async Task Handle(CustomerCreatedEvent message)
    {
        var customer = new Customer
        {
            Id = message.Id,
            Email = message.Email,
            Firstname = message.Firstname,
            Lastname = message.Lastname,
            DateOfBirth = message.DateOfBirth,
            PhoneNumber = message.PhoneNumber,
            BankAccountNumber = message.BankAccountNumber
        };
        _context.Customer.Add(customer);
        await _context.SaveChangesAsync();
    }
}