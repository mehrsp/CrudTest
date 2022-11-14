using Domain.Customers.Services;
using Microsoft.EntityFrameworkCore;
using ReadInfra;
using ServiceContracts.Customers;

namespace Services.Customers.EventHandlers;

public class CustomerUpdatedEventHandler
{
    private readonly ReadDataContext _context;

    public CustomerUpdatedEventHandler(ReadDataContext context)
    {
        _context = context;
    }

    protected  async Task Handle(CustomerUpdatedEvent message)
    {

        var res = await _context.Customer.Where(x => x.Id == message.Id).FirstAsync();



        res.Email = message.Email;
        res.Firstname = message.Firstname;
        res.Lastname = message.Lastname;
        res.DateOfBirth = message.DateOfBirth;
        res.PhoneNumber = message.PhoneNumber;
        res.BankAccountNumber = message.BankAccountNumber;
            
        await _context.SaveChangesAsync();
    }
}