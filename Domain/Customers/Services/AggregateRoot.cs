namespace Domain.Customers.Services;

public class AggregateRoot
{
    public int Id { get; set; }
    
    public void AddEvent(DomainEvent @event)
    {
    }
}

public class DomainEvent 
{
    public long Id { get; set; }
}