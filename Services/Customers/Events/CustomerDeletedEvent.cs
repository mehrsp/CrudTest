namespace Domain.Customers.Services;

public class CustomerDeletedEvent
{
    public CustomerDeletedEvent(int id)
    {

        Id = id;
    }
    public int Id { get; set; }
}