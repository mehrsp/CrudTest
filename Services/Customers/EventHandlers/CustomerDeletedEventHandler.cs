using Domain.Customers.Services;
using Microsoft.EntityFrameworkCore;
using ReadInfra;
using ServiceContracts.Customers;

namespace Services.Customers.EventHandlers;

public class CustomerDeletedEventHandler
{
    private readonly ReadDataContext _context;

    public CustomerDeletedEventHandler(ReadDataContext context)
    {
        _context = context;
    }

    protected  async Task Handle(CustomerDeletedEvent message)
    {

        var res = await _context.Customer.Where(x => x.Id == message.Id).FirstAsync();

        _context.Customer.Remove(res);
            
        await _context.SaveChangesAsync();
    }
}