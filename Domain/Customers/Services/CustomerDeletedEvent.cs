namespace Domain.Customers.Services;

public class CustomerDeletedEvent:DomainEvent
{
    public CustomerDeletedEvent(int id)
    {

        Id = id;
    }
    
}